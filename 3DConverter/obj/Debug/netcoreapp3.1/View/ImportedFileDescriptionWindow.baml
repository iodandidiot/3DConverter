   M S B A M L   `   `   `  ����F  B3DConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_3DConverter_3DConverter  5   	   0    *_3DConverter.ImportedFileDescriptionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_3DConverter     5   	     � Title$  FileDescriptionWindow��5   	   $	��250��6'   $	��400��64   .��5	      � ��6   ��  �� Path$ 
Background� � RowDefinitions 5
   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��0��6/   $��0��6?   $��Center=�6L   $��10(�6i   $��	File Name��6w   �� 5   
   $��Center=�6   $��1��60   $��0��6@   $��Center=�6M   $��18(�6j   ��5      �� $ FileName��� 5   
   $��Center=�6   $��0��6/   $��1��6?   $��Center=�6L   $��10(�6i   $��File Original Path��6w   �� 5   
   $��Center=�6   $��1��6/   $��1��6?   $��Center=�6L   $��10(�6i   ��5      �� $ FileOriginalPath��� 5   
   $��Center=�6   $��0��6/   $��2��6?   $��Center=�6L   $��10(�6i   $��Convert count��6w   �� 5   
   $��Center=�6   $��1��6/   $��2��6?   $��Center=�6L   $��10(�6i   ��6w   �� $ ConvertedCount��� 5   
   
���  ��$��1��6&   $��3��66   $��Center=�6i   $��Delete File��5      $��	22,0,37,0q�6'   ��5   C   �� *DeleteFileCommand+5   '   5      5      