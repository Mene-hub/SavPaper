   M S B A M L   `   `   `  ���� E  ASavePaper, Version=1.11.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SavePaper	SavePaper      SavePaper.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:SavePaper     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$ 	SavePaper��$	��450��$	��800�� � 
ResizeMode$ NoResize=�.��� ���	#FFD6D6D6 � RowDefinitions �� $	��43* ��� $
��376* � � ColumnDefinitions �� $��2* ��� $��1* �.+�#  MaterialDesignThemes.Wpf.Card  $��1��
����������	#FF232323$��25q�   UniformCornerRadius$ 10Q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�$��2��$��20,0,0,0q�.���  �� $	��45* ��� $
��281* ��� $	��50* �.+��� -    ��Name$ 	PaperName��$��Center=�$
��Bold"�$��0��$��Nome Scontrino���� $��1��$��Hidden=�.���� -   $��PaperInList��$��1��$
��Left=�	 �� CanVerticallyScroll	 . $	��277��$	��277��$	��277��$��Hidden=��� -   $��totPrice��$��2��$
��Left=�$��Center=�$
��Bold"�.��	Tot: 0€�� -   
 ��Name$
 NewPaper_BT��$��2�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��0,0,10,5q�$��Right=� � ToolTip$ Nuovo scontrino����0  *MaterialDesignThemes.Wpf.PackIconExtension  *Add+�� -   $
 NDeletePaper_BT��$��2��#��[ $��0,0,55,5q�$��Right=�$ Cancella scontrino�����	#FFFE3030���	#FFFE3030$��30��$��30����  *Minus+�� -   $��
PapersList��$��Center=�$��Center=����	#FFECECEC���	#DD000000$
��Bold"����	#89000000$��0q��� -   $��SortBT��$��1��$	��Top=�$��30�����	#FFE2E2E2
�������$��Center=�$��Center=� � Cursor$
 Hand��.��Data Crescente ↑↓�� -   $��	PaperList��$��Center=����	#FFECECEC$��1��$	��288��$	��Top=�$��0,30,0,0q�$	��288��$	��288���� -	   $
 ExportBT��#��[ $��	10,0,0,60q�$
��Left=�$��Bottom=�$��0q����	#DDFFFFFF$ Esporta Gruppo�����	#FF363636$��30��$��30�� K� ZIndex$ 99��$��1����  *Export+��Z� �� $��1��$��60��$��Bottom=� �� Orientation$ 
Horizontal=�$��0q����	#FFECECEC.+��� -
   $
 GroupSettingsBT��$��1��#��[ $��	10,0,0,15q�$��Right=�$��Bottom=�$��0q����	#DDFFFFFF$ Setta un Budget�����	#FFFFC500$��30��$��30��$ 99����  *Euro+��Z�   -     Name$ 
BudgetView��$��1��$��30��$	��150��
�������$ 15Q�$��Center=�$��Bottom=�$��
-30,0,0,15q�$y�Hidden=�.���� -   $��BudgetLB��$
��Left=�$��Center=�$
��Bold"�$��35,1,0,0q�.��Budget: 0€�� -    ��Name$ StackOpacity��$��Bottom=�$��1��$ 
Horizontal=�$��Right=�$��0q�$��60��.+��� -   $
 DeletePapersBT��$��1��#��[ $��	0,0,10,15q�$��Right=�$��Bottom=�$��0q����	#DDFFFFFF$ Cancella gruppo scontrini��
���  ��$��30��$��30����  *Minus+��Z� �� -   $
 newPapersBT��$��1��#��[ $��	0,0,10,10q�$��Right=�$��Bottom=�$��0q����	#DD000000$ Nuovo gruppo scontrini��
���������  *Add+��Z� �� -   $
 excelBT��$��1��#��[ $��	0,0,10,10q�$��Right=�$��Bottom=����	#FF00A416$��0q�$ Apri con Excel����  *MicrosoftExcel+��Z� �� -   $
 SpesaTotale_BT��#��[ ���	#DDFFFFFF���	#FF304FFE���	#FF304FFE$��1��$��Right=�$��Bottom=�$��	0,0,10,10q�$ Spesa Totale����  *	Summation+� -   $��AddPapersList��$��2��$��2��$y�Hidden=�����  �� Color$ Black�� �� Opacity$	 0.4Q�.+�  $	��300��$	��150��$ 10Q�.���� $��Center=�$��Center=�.+��� $��Center=�$��Center=�$
��Bold"�.��Nome gruppo scontrini�� -   $��NewPapersListNameTB��$��0,10,0,0q�$��Center=�$��Center=��� $ 
Horizontal=�$��Center=�$��0,10,0,0q�$��1��$��Center=�.+��� -   $
 CloseNewPapersBT��#��[ $ Close��$��0,0,5,0q����	#FFF40303���	#FFF40303���	#DDFFFFFF$��30��$��30��$��Center=�$��Center=���  *Close+�� -   $
 AcceptNewPapersBT��#��[ $
 Icon��$��5,0,0,0q����	#DDFFFFFF$��30��$��30��#��� �����	#FF0078D7$��Center=�$��Center=���  *Done+� -   $��AddPaper��$��2��$��2��$y�Hidden=����� $ Black��$	 0.4Q�.+�  $	��220��$	��371��$ 10Q�.���  �� $	��32* ��� $��5* �.+��� $��10q�.+��� $��0,5,0,0q�.��Motivazione�� -    ��Name$ 
TB_Movente���� $��0,5,0,0q�.��	Venditore�� -   $ TB_Venditore���� $��0,5,0,0q�.��Data(  "System.Windows.Controls.DatePicker  -     Name$ DP_Date���� $��	0,5,0,-10q�.��
Prodotti�� $��10(�$��	0,0,0,-10q�.��%#separa i prodotti come nell'esemio:�� $��10(�$
��Bold"�.��pasta 5€; carne 10€�� -   $ TB_listaSpesa��$��90��
��������� $ 
Horizontal=�$��Center=�$��0,0,10,0q�$��1��$��Right=�.+��� -   $
 closePaperBT��#��[ $ Close��$��0,0,5,0q����	#FFF40303���	#FFF40303���	#DDFFFFFF$��30��$��30��$��Center=�$��Center=���  *Close+�� -   $
 AcceptPaperBT��#��[ $
 Icon��$��5,0,0,0q����	#DDFFFFFF$��30��$��30��#��� �����	#FF0078D7$��Center=�$��Center=���  *Done+� -   $��SettingsGrid��$��2��$��2��$y�Hidden=����� $ Black��$	 0.4Q�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�  $	��250��$	��200��$ 10Q�$��Center=�$��Center=�$��0q�.���� $ Vertical=�$��Center=�.+��� $��0,5,0,0q�$��Center=�$��Center=�.��Imposta un budget�� -   $ 	TB_Budget��$��Center=�$��Center=�$��Center=�$
��50,0q��� $��Center=�$��0,10,0,0q�.��solo nuovi scontrinid� -   $��Toggle_Budget���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+��� -    $
 closeSettingsT��#��[ $ Close��$��0,0,5,0q����	#FFF40303���	#FFF40303���	#DDFFFFFF$��30��$��30��$��Center=�$��Center=���  *Close+�� -!   $
 AccepSettings��#��[ $
 Icon��$��5,0,0,0q����	#DDFFFFFF$��30��$��30��#��� �����	#FF0078D7$��Center=�$��Center=���  *Done+�� $��7(�$��Bottom=�$��Right=�$��1��$��1��.��*(SavePaper Developed by Menegotto Claudio