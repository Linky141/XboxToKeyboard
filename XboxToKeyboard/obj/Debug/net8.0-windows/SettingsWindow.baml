   M S B A M L   `   `   `  ����I  EXboxToKeyboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:XboxToKeyboardXboxToKeyboard  5   	   #    XboxToKeyboard.SettingsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:XboxToKeyboard     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   :md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  SettingsWindow��5   	   $	��450��6    $	��800��6-      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � .+�5   
   �� -   5         ��Name$ sliderAnalogDeadzone��5      $��Center=�6/   $��0,69,0,0q�6L   $	��Top=�6^   $	��780��6v   6�   �� 5   
   -   5         ��Name$ textboxAnalogDeadzone��5      $��Center=�61   $��0,39,0,0q�6N    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��780��6�   6�   �� 5   
   $��Analog deadzone��6   $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   �� 5   
   -   5         ��Name$ labelArrowDown��5      $
��Left=�6(   $��
59,142,0,0q�6C   $	��Top=�6W   $y�Hidden=�6o   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowDown=�6   $��16��6/   $��16��6:   $��Center=�6F   $
��Left=�6a   $��5,0,5,0q�6|   5      5      �� 5   
   -   5        $ labelArrowRight��5      $
��Left=�6)   $��
76,118,0,0q�6D   $	��Top=�6X   $y�Hidden=�6p   .��5      �� $ 
Horizontal=�6   .+�5        $ 
ArrowRight=�6   $��16��60   $��16��6;   $��Center=�6G   $
��Left=�6b   $��5,0,5,0q�6}   5      5      �� 5    
   -   5        $ labelArrowLeft��5       $
��Left=�6(   $��
42,118,0,0q�6C   $	��Top=�6W   $y�Hidden=�6o   .��5!      �� $ 
Horizontal=�6   .+�5"        $ 	ArrowLeft=�6   $��16��6/   $��16��6:   $��Center=�6F   $
��Left=�6a   $��5,0,5,0q�6|   5#      5$      �� 5%   
   -   5        $ labelArrowUp��5%      $
��Left=�6&   $��	59,94,0,0q�6A   $	��Top=�6T   $y�Hidden=�6l   .��5&      �� $ 
Horizontal=�6   .+�5'        $ ArrowUp=�6   $��16��6-   $��16��68   $��Center=�6D   $
��Left=�6_   $��5,0,5,0q�6z   5(      5)      �� 5*   
   -   5        	 ��Name$"	 buttonThumbstickDeadzoneSave��5*        MaterialDesignFlatButton#��[ 67   
������$
��Left=�6�   $��	116,7,0,0q�6�   $	��Top=�6�   .��5+      �� $ 
Horizontal=�6   .+�5,        $ ContentSave=�6   $��15��61   $��15��6<   $��Center=�6H   $
��Left=�6c   $��5,0,5,0q�6~   5-      5.      50      51      