   M S B A M L   `   `   `  ����G  CPostmanClone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PostmanClone.ViewsPostmanClone.Views  5   	   #    PostmanClone.Views.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PostmanClone.Views     5   	     � Title$  PostmanClone��5   	   $	��350��6   $	��500��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��4* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   .+�5      �� $��70��6   $��25��5      $��2q�5      ��5      �� *RequestTypes+ �� SelectedItem 5      �� *SelectedRequestType+5      �� 5      $��25��6   $	��180��6"   $��2q�6.   ��69   �� *
RequestUrl+6W   �� 5      $��25��6   $��2q�6!   $��5 3 5 3q�6,   ��6>   �� *SendRequestCommand+.��6e   Send6k   5      �� 5   
   $��1��6   $��Center=�6"   .+�5!      �� $	��220��6   $	��320��6&    63   �� *SelectedTab+.@�5"      �� $
��Body��6   .��5#      �� $	��200��6   $	��300��5$      " �� VerticalScrollBarVisibility$
 Auto=�5'      $ �� HorizontalScrollBarVisibility$
 Auto=�5(       �� 
IsReadOnly 5%      �� *IsReadOnlyResponseText+��5&      �� *ResponseBody+5(      5)      �� 5*      $��Result��6   .��5+      �� $
 True��6   $	��200��5,      $	��300��5-      $
 Auto=�5/      $
 Auto=�50      ��5.      �� *Result+50      51      52      �� 54      $
��Copy��6   $��50��55      $��Right=�56      ��57      �� *CopyToClipboardCommand+58      59      5:      