   M S B A M L   `   `   `  ����I  EXboxToKeyboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:XboxToKeyboardXboxToKeyboard  5   	       XboxToKeyboard.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:XboxToKeyboard     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      :md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  windowMainWindow��5   F   $	��554��5   
   $
��1124��6    � 
ResizeMode$ NoResize=�6$      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � .+�5   
   �� -   5         ��Name$ listboxConsole��5      $��684,10,10,0q�6*   $	��515��6?   $	��Top=�6L   �� 5   
   $��Status: ��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5         ��Name$ labelConnectionStatus��5      $	��---��6/   $
��Left=�6=   $��	58,10,0,0q�6X   $	��Top=�6k   �� 5   
   -   5         ��Name$ buttonConnectController��5      $
��Left=�63   $��
155,0,0,13q�6N   $��Bottom=�6b   $��71��6}   $	��524��6�   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
Connection=�6   $��16��60   $��16��6;   $��Center=�6G   $
��Left=�6b   $��5,0,5,0q�6}   �� 5      $��Connect controller��6   $��Center=�66   5      5      �� 5   
   -   5        $ buttonXboxLeftTrigger��5   G      MaterialDesignOutlinedButton#��[ 6   $�� ��6f   $��60��6q   $
��Left=�6|   $��	17,42,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ buttonXboxLeftBumper��5   G   #��[ 6   $�� ��6e   $��60��6p   $
��Left=�6{   $��	17,79,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ buttonXboxRightTrigger��5   G   #��[ 6   $�� ��6g   $��60��6r   $
��Left=�6}   $��
619,42,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ buttonXboxRightBumper��5   G   #��[ 6   $�� ��6f   $��60��6q   $
��Left=�6|   $��
619,79,0,0q�6�   $	��Top=�6�   6�   �� 5    
   -	   5        $ buttonXboxLeftAnalogUp��5    G   #��[ 6   $�� ��6g   $��60��6r   $
��Left=�6}   $��120,125,0,0q�6�   $	��Top=�6�   6�   �� 5!   
   -
   5        $ buttonXboxLeftAnalogLeft��5!   G   #��[ 6   $�� ��6i   $��60��6t   $
��Left=�6   $��
54,161,0,0q�6�   $	��Top=�6�   6�   �� 5"   
   -   5        $ buttonXboxLeftAnalogRight��5"   G   #��[ 6   $�� ��6j   $��60��6u   $
��Left=�6�   $��184,161,0,0q�6�   $	��Top=�6�   6�   �� 5#   
   -   5        $ buttonXboxLeftAnalogDown��5#   G   #��[ 6   $�� ��6i   $��60��6t   $
��Left=�6   $��120,197,0,0q�6�   $	��Top=�6�   6�   �� 5$   
   -   5        $ buttonXboxDpadUp��5$   G   #��[ 6   $�� ��6a   $��60��6l   $
��Left=�6w   $��229,298,0,0q�6�   $	��Top=�6�   6�   �� 5%   
   -   5        $ buttonXboxDpadLeft��5%   G   #��[ 6   $�� ��6c   $��60��6n   $
��Left=�6y   $��165,324,0,0q�6�   $	��Top=�6�   6�   �� 5&   
   -   5        $ buttonXboxDpadRight��5&   G   #��[ 6   $�� ��6d   $��60��6o   $
��Left=�6z   $��294,324,0,0q�6�   $	��Top=�6�   6�   �� 5'   
   -   5        $ buttonXboxDpadDown��5'   G   #��[ 6   $�� ��6c   $��60��6n   $
��Left=�6y   $��229,348,0,0q�6�   $	��Top=�6�   6�   �� 5(   
   -   5        $ buttonXboxRightAnalogUp��5(   G   #��[ 6   $�� ��6h   $��60��6s   $
��Left=�6~   $��441,287,0,0q�6�   $	��Top=�6�   6�   �� 5)   
   -   5        $ buttonXboxRightAnalogLeft��5)   G   #��[ 6   $�� ��6j   $��60��6u   $
��Left=�6�   $��377,324,0,0q�6�   $	��Top=�6�   6�   �� 5*   
   -   5        $  buttonXboxRightAnalogRight��5*   G   #��[ 6   $�� ��6k   $��60��6v   $
��Left=�6�   $��505,324,0,0q�6�   $	��Top=�6�   6�   �� 5+   
   -   5        $ buttonXboxRightAnalogDown��5+   G   #��[ 6   $�� ��6j   $��60��6u   $
��Left=�6�   $��441,361,0,0q�6�   $	��Top=�6�   6�   �� 5,   
   -   5        $ buttonXboxY��5,   G   #��[ 6   $�� ��6\   $��60��6g   $
��Left=�6r   $	��Top=�6�   $��516,137,0,0q�6�   �� 5-   
   -   5        $ buttonXboxX��5-   G   #��[ 6   $�� ��6\   $��60��6g   $
��Left=�6r   $��451,162,0,0q�6�   $	��Top=�6�   6�   �� 5.   
   -   5        $ buttonXboxB��5.   G   #��[ 6   $�� ��6\   $��60��6g   $
��Left=�6r   $��581,162,0,0q�6�   $	��Top=�6�   6�   �� 5/   
   -   5        $ buttonXboxA��5/   G   #��[ 6   $�� ��6\   $��60��6g   $
��Left=�6r   $��516,187,0,0q�6�   $	��Top=�6�   6�   �� 50   
   -   5        $ buttonXboxSelect��50   G   #��[ 6   $�� ��6a   $��60��6l   $
��Left=�6w   $��287,197,0,0q�6�   $	��Top=�6�   6�   �� 51   
   -   5        $ buttonXboxStart��51   G   #��[ 6   $�� ��6`   $��60��6k   $
��Left=�6v   $��353,197,0,0q�6�   $	��Top=�6�   6�   �� 52   
   -   5        $ buttonSaveConfig��52   [     MaterialDesignFlatButton#��[ 6   
������$	��140��6u   $
��Left=�6�   $��	10,0,0,13q�6�   $��71��6�   $��Bottom=�6�   .��53      �� $ 
Horizontal=�6   .+�54        $ ContentSave=�6   $��30��61   $��30��6<   $��Center=�6H   $
��Left=�6c   $��5,0,5,0q�6~   55      56      �� 57   
   -   5        $ buttonXboxLeftAnalog��57   G   #��[ 6   $�� ��6e   $��60��6p   $
��Left=�6{   $��120,161,0,0q�6�   $	��Top=�6�   6�   �� 58   
   -   5        $ buttonXboxRightAnalog��58   G   #��[ 6   $�� ��6f   $��60��6q   $
��Left=�6|   $��441,324,0,0q�6�   $	��Top=�6�   6�   �� 59   
   -   5        $ buttonSettings��59      #��[ 6)   $
��Left=�6[   $��	10,0,0,89q�6v   $��78��6�   $��32��6�   $��Bottom=�6�   .��5:      �� $ 
Horizontal=�6   .+�5;        $ settings=�6   $��30��6.   $��30��69   $��Center=�6E   $
��Left=�6`   $��5,0,5,0q�6{   5<      5=      5>      5?      