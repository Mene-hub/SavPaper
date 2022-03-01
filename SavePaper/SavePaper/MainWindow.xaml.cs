﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SavePaper
{
    public partial class MainWindow : Window
    {
        //lista degli scontrini aggiunti
        List<Scontrino> spese;
        string[] myPapers;

        //costruttore della window
        public MainWindow()
        {
            InitializeComponent();

            //controllo se ci sono dei gruppi di scontrini già salvati
            //altrimenti visualizzo il popup per l'inserimento
            if (FileManager.getPapersList().Length == 0)
                AddPapersList.Visibility = Visibility.Visible;
            else
            {
                spese = new List<Scontrino>();
                myPapers = FileManager.getPapersList();
                PapersList.ItemsSource = myPapers;
                updateListBox();
            }
            PapersList.SelectedIndex = 0;
        }

        //metodo che in base alla lista di scontrini (spese) svuota e riempie la list box con gli contrini aggiornati
        public void updateListBox()
        {

            ListBoxItem labelItem;
            PaperList.Items.Clear();
            foreach (var item in spese)
            {
                labelItem = new ListBoxItem();
                labelItem.Selected += LabelItem_Selected;
                labelItem.Background = Brushes.White;
                labelItem.Foreground = Brushes.Black;
                labelItem.Height = 40;
                labelItem.VerticalAlignment = VerticalAlignment.Center;
                labelItem.HorizontalAlignment = HorizontalAlignment.Center;
                labelItem.Width = 519;
                labelItem.Margin = new Thickness(5, 5, 5, 0);
                labelItem.Content = item.movente + ", data: " + item.dataAcquisto.ToString().Split(' ')[0];

                PaperList.Items.Add(labelItem);
            }
        }

        //evento causato dalla selezione di uno scontrino dalla list box
        //aggiorna l'anteprima dello scontrino sulla view a destra
        private void LabelItem_Selected(object sender, RoutedEventArgs e)
        {
            //prendo il movente
            int id = PaperList.Items.IndexOf(((ListBoxItem)sender));
            PaperName.Content = spese[id].movente;

            //faccio il conto del prezzo totale dello scontrino
            totPrice.Content = "Tot: " + (spese[id].totCost()) + "€";

            Label spesa;
            PaperInList.Children.Clear();

            //stampo la lista dello scontrino
            foreach (var item in spese[id].scontrino)
            {
                spesa = new Label();
                spesa.Content = item.nome + ":      " + item.costo + "€";
                PaperInList.Children.Add(spesa);
            }
            
        }
        
        //evento richiamato per l'aggiunta di un nuovo scontrino nel gruppo selezionato
        //rende visibile il popup per l'inserimento dei dati
        private void NewPaper_BT_Click(object sender, RoutedEventArgs e)
        {
            if (PapersList.Items.Count > 0 && PapersList.SelectedIndex >= 0)
                AddPaper.Visibility = Visibility.Visible;
        }

        //evento richiamato da entrambi i bottoni nel popup per il nuovo scontrino
        private void closeNewPaper(object sender, RoutedEventArgs e)
        {
            //rimpiazzo gli spazi per evitare che il nome sia composto da soli caratteri "vuoti"
            string venditore = TB_Venditore.Text;
            venditore.Replace(" ", "");

            string movente = TB_Movente.Text;
            movente.Replace(" ", "");

            string lista = TB_listaSpesa.Text;

            //faccio tutti i controlli per lasciare visibile il popup o il salvataggio dei file
            if (venditore != "" && movente != "" && lista != "" && ((Button)sender).Equals(AcceptPaperBT))
            {
                if (PapersList.Items.Count > 0 && PapersList.SelectedIndex >= 0) {
                    try
                    {
                        //"de serializzo" i dati inseriti nel form per creare un istanza di Scontrino
                        List<SingolaSpesa> spese_ = new List<SingolaSpesa>();

                        //divido il prodotto dal suo prezzo e lo aggiungo alla lista di SingolaSpesa dell scontrino
                        for (int i = 0; i < lista.Split(' ').Length; i += 2)
                        {
                            if (lista.Split(' ')[i + 1].Contains('€'))
                                spese_.Add(new SingolaSpesa(double.Parse(lista.Split(' ')[i + 1].Replace("€", "")), lista.Split(' ')[i]));
                            else
                                throw new Exception("errore nell'inserimento dei prezzi");
                        }

                        //aggiungo lo scontrino
                        spese.Add(new Scontrino(TB_Movente.Text, TB_Venditore.Text, DP_Date.SelectedDate.Value, spese.Count));
                        
                        //aggiungo all'ultimo scontrino aggiunto la lista di prodotti
                        spese.Last().addSpesa(spese_);
                        updateListBox();
                        AddPaper.Visibility = Visibility.Hidden;
                    }
                    catch (Exception E) { MessageBox.Show("errore nell'inserimento dei dati: " + E.Message); return; }

                }
                else
                if (((Button)sender).Equals(AcceptPaperBT))
                    return;

                clearPaper();
                FileManager.salvaScontrini(spese, PapersList.SelectedItem.ToString());
            }
            if (((Button)sender).Equals(AcceptPaperBT))
                return;

            AddPaper.Visibility = Visibility.Hidden;
        }

        //evento per la visualizzazione del popup, che visualizza il totale speso del gruppo scontrini
        private void SpesaTotale_BT_Click(object sender, RoutedEventArgs e)
        {
            if (PapersList.Items.Count > 0 && PapersList.SelectedIndex >= 0)
            {
                double totSpesa = 0;
                foreach (var item in spese)
                {
                    totSpesa += item.totCost();
                }
                MessageBox.Show("spesa totale: " + totSpesa + "€");
            }
        }

        //evento richiamato dal pulsante verde
        private void openWithExcel(object sender, RoutedEventArgs e)
        {

            //richiama il metodo per il salvataggio del file, la sua formattazione il salvataggio
            FileManager.writeExcel(spese, PapersList.SelectedItem.ToString());

            //controllo se è sensata l'apertura del file
            if (PapersList.Items.Count > 0 && PapersList.SelectedIndex >= 0) {
                if (spese.Count > 0)
                {
                    //ricreo il path completo del file per la sua apertura
                    string fileName = FileManager.path + PapersList.SelectedItem.ToString() + ".xlsx";
                    //apro il file salvato con excel
                    try
                    {
                        //new ExcelOpener(fileName).ShowDialog();
                        Process.Start(fileName);
                    }
                    catch (Exception E) {
                        if (MessageBox.Show("impossibile aprire il file, vuoi provare a visualizzarlo qui?", "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            new ExcelOpener(fileName).ShowDialog();
                    }
                }
                else
                    MessageBox.Show("non ci sono scontrini da visualizzare", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //evento richiamato dalla 
        private void updatePaperlist(object sender, SelectionChangedEventArgs e)
        {
            if (PapersList.SelectedItem != null)
            {
                spese = FileManager.loadScontrini(PapersList.SelectedItem.ToString());
                spese.Sort((x, y) => x.dataAcquisto.CompareTo(y.dataAcquisto));
            }
            else
                spese = new List<Scontrino>();

            updateListBox();
            clearPaper();
            PaperList.SelectedIndex = -1;
            clearPaperView();

        }

        //metodo che pulisce il form per la creazione del nuovo scontrino
        private void clearPaper()
        {
            TB_Movente.Text = "";
            TB_Venditore.Text = "";
            DP_Date.SelectedDate = null;
            TB_listaSpesa.Text = "";

            AddPaper.Visibility = Visibility.Hidden;
        }

        //metodo che pulisce l'anteprima dello scontrino selezionato
        private void clearPaperView()
        {
            PaperName.Content = "Nome Scontrino";
            totPrice.Content = "Tot: 0€";
            PaperInList.Children.Clear();
        }

        //metodo per la visualizzazione del form per la creazione del nuovo gruppo scontrini
        private void newPapersBT_Click(object sender, RoutedEventArgs e)
        {
            AddPapersList.Visibility = Visibility.Visible;
        }

        //evento utilizzato da entrambi i pulsanti nel popup
        private void closeNewPapersList(object sender, RoutedEventArgs e)
        {
            //setto la variabile per il controllo che non ci siano solo spazi
            string newName = NewPapersListNameTB.Text;
            newName = newName.Replace(" ", "");

            //controllo se il nome inserito è accettabile
            if (newName != "" && ((Button)sender).Equals(AcceptNewPapersBT))
            {
                //controllo e creo il nuovo file
                FileManager.filecheck(NewPapersListNameTB.Text);

                //svuoto la Textbox, nascondo il popup e aggiorno la lista di gruppi nella combobox
                NewPapersListNameTB.Text = "";
                AddPapersList.Visibility = Visibility.Hidden;
                myPapers = FileManager.getPapersList();
                PapersList.ItemsSource = myPapers;
                return;
            }

            //nel caso non ci siano gruppi di scontrini non voglio che il popup si chiuda, è obbligato a mettere almeno un gruppo con un nome != vuoto
            if (PapersList.Items.Count == 0 && newName == "")
            {
                AddPapersList.Visibility = Visibility.Visible;
                return;
            }

            //nel caso non ci siano gruppi di scontrini non voglio che il popup si chiuda, è obbligato a mettere almeno un gruppo quindi non è possibile premere X
            if (PapersList.Items.Count == 0 && newName != "" && ((Button)sender).Equals(CloseNewPapersBT))
            {
                AddPapersList.Visibility = Visibility.Visible;
                return;
            }

            //per esclusione se ci sono gruppi di scontrini è possibile annullare la creazione di un gruppo
            if (newName == "" || ((Button)sender).Equals(CloseNewPapersBT))
                AddPapersList.Visibility = Visibility.Hidden;

            //svuota la TextBox se la creazion viene annullata
            if(((Button)sender).Equals(CloseNewPapersBT) && PapersList.Items.Count > 0)
                NewPapersListNameTB.Text = "";
        }

        //evento per la rimozione di uno scontrino
        private void RemovePaper(object sender, RoutedEventArgs e)
        {
            //popup son la conferma SI/NO
            if (MessageBox.Show("sei sicuro di voler cancellare lo scontrino?", "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.Yes) {
                if (PapersList.Items.Count > 0 && PapersList.SelectedIndex >= 0)
                {
                    //rimuovo dalla lista di scontrini l'istanza riferita allo scontrino selezionato
                    int idRemoved = PaperList.Items.IndexOf(((ListBoxItem)PaperList.SelectedItem));
                    spese.RemoveAt(idRemoved);

                    //aggiorno la listBox in base alla lista scontrini aggiornata
                    updateListBox();

                    //salvo la lista scontrini aggiornata
                    FileManager.salvaScontrini(spese, PapersList.SelectedItem.ToString());

                    //svuoto l'anteprima dello scontrino sulla destra
                    clearPaperView();
                }
            }
        }

        //evento per la rimozione di un gruppo di scontrini
        private void DeletePapersBT_Click(object sender, RoutedEventArgs e)
        {
            //popup son la conferma SI/NO
            if (MessageBox.Show("sei sicuro di voler cancellare il gruppo scontrini?", "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                if (PapersList.Items.Count > 0)
                {
                    FileManager.deleteFile(PapersList.SelectedItem.ToString());
                    myPapers = FileManager.getPapersList();
                    PapersList.ItemsSource = myPapers;
                    PapersList.SelectedIndex = 0;

                    if (PapersList.Items.Count == 0)
                        AddPapersList.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
