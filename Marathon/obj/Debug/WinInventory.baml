   M S B A M L   `   `   `  ����C  ?Marathon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MarathonMarathon  5   	       Marathon.WinInventory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Marathon     5   	     � Title$&   Marathon Skills 2016 - Inventory��5   	   $	��600��62   $	��800��6?    � WindowStartupLocation$ CenterScreen=�6K    � 	Resources 5	         myHeaderStyle �� 
TargetType �� Property �� Value  FocusVisual J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  ButtonStyle	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 O     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &	 �    &		 �    &	
     &	 4    7  7  7  7  7  7  7  7  7 	 7 
 �� 5
   
   " ��6&   .�5      ��  � y�$ 	Collapsed=�6+   5      �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6$   .�5       ��  �@�FocusVisualStyle8   61   �� 5!       � ��8  6+   �� 5"       � ��8  6,   �� 5#       � �� �#3d3d3d6+   �� 5$       � ��$ 1q�60   �� 5%       � ��$ 20(�6)   �� 5&       � ��$ Center=�6;   �� 5'       � ��$ Center=�69   �� 5(       � ��$ 1q�6(   �� 5)       � �� 5*      �� 5+      "	 ��6&   .R�5,      �� $
 border��6!   $ 10��61   #��z��6C   #��z��6o   #��z��6�    . ._�5-      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5.       5/      P� 50       �@��IsDefaulted . . �51   "   �� $ border��6@   # � ��6T    � ��52      P� 53       �@J�IsMouseOver . . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � �� . . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   5:      P� 5;       � {� .  . �5<   "   �� $ border��6?   8   � ��6S   �� 5=   "   $ border��6@   8   � ��6T   �� 5>   "   $ contentPresenter��6K   8 	  � ��6i   5?      5A      5C      5D      5E      .��5F      �  � ColumnDefinitions 5G   
   �� 5H      $	��19* �6   �� 5I      $	��66* �6   �� 5J      $	��46* �6   �� 5K      $	��80* �6   �� 5L      $
��182* �6   �� 5M      $
��205* �6   �� 5N      $	��54* �6   �� 5O      $
��110* �6   �� 5P      $	��31* �6    � RowDefinitions 5R   
   �� 5S      $	��25* �6   �� 5T      $	��45* �6   �� 5U      $	��25* �6   �� 5V      $	��40* �6   �� 5W      $	��35* �6   �� 5X      $	��85* �6   �� 5Y      $	��34* �6   �� 5Z      $
��193* �6   �� 5[      $	��12* �6   �� 5\      $	��30* �6   �� 5]      $	��12* �6   �� 5^      $	��34* �6   .+�5`   
   �� $��Marathon Skills 2016��6   ���	#FF434347
�������$��35(�6Y   $
��Left=�6g   $��Center=�6�   $
��Bold"�6�   $��Arial)�6�   $��4��6�   $��3��6�   $��5��6�   $��0,0,0.001,0q�6  �� 5a   
   $�� ��6   ���	#FF434347$��4��62   $��3��6F   �� 5b   
   -   5        $��BtnBack��5b      $��
Назад��66   $��1��6F   $��1��6V   #���  6c   $��2��6�   �� 5c   
   -   5        $��LblTime��5c      $�� ��6   ���	#FF434347
�������$��20(�6T   $��Center=�6b   $��Center=�6�   $��Arial)�6�   $��11��6�   $��9��6�   $��0,0,0.001,0q�6�   �� 5d   
   $��Инвентарь��6   $��20(�6$   $��Center=�62   $��Center=�6T   $��Arial)�6x   $
��Bold"�6�   ���#3d3d3d$��1��6�   $��3��6�   $��7��6�   $��39,0,0.001,0q�6�   �� 5e   
   $V��PВсего зарегистрировано бегунов на марафон :��6   $��15(�6F   $
��Bold"�6T   $��Center=�6f   $��Center=�6�   $��1��6�   $��4��6�   $��4��6�   �� 5f   
   -   5         ��Name$ 	BtnLogout��5f      $��Logout��6<   $��7��6M   $��1��6]   #���  6j   $��0,0,0.001,0q�6�   �� 5g   
   -   5        $��LblRunnersCount��5g      $�� ��6)   $��5��64   $��4��6D   $��15(�6Q   $
��Left=�6_   $��Center=�6�   $��2��6�   �� 5h   
   -   5        $��
TypesCount��5h      $��7��6%   $��11(�69   $��Center=�6G   $��Center=�6i   $��1��6�   $��5��6�   $��0,0,0.001,0q�6�    �� View 5i      �� 5j      .P�5k      �� $��Комплект��6%    �� Width$	 150��67    �� CellTemplate 5l      �� 5m      .R�5n   "   �� $��WrapWithOverflow=�6,   $2��,Выбрало\nданный\nвариант��6L   5o      5r      �� 5s      $��	Тип А��6%   $	 100��64    5t      �� 5u      .R�5v   "   �� $��WrapWithOverflow=�6,   ��6L   �� *TypeA+5w      5y      �� 5z      $��Тип B��6%   $	 100��64    5{      �� 5|      .R�5}   "   �� $��WrapWithOverflow=�6,   ��6L   �� *TypeB+5~      5�      �� 5�      $��Тип C��6%   $	 100��64    5�      �� 5�      .R�5�   "   �� $��WrapWithOverflow=�6,   ��6L   �� *TypeC+5�      5�      �� 5�      $��Необходимо��6%   $	 150��69    5�      �� 5�      .R�5�   "   �� $��WrapWithOverflow=�6,   ��6L   �� *Sum+5�      5�      �� 5�      $��Остаток��6%   $	 150��66    5�      �� 5�      .R�5�   "   �� $��WrapWithOverflow=�6,   ��6L   �� *Ost+5�      5�      5�      5�      �� 5�   
   
���   �$��1q�6%   $��1��69   $��6��6I   $��7��6V   $��0,0,0.001,0q�6j   ._�5�      �� $%��Состав комплекта��6   $��15(�6/   $
��Bold"�6=   $��Center=�6O   $��Center=�6s   5�      �� 5�   
   -   5        $��ListComposition��5�      $��1q�6*   
���   �$��11(�6R   $��Center=�6`   $��Center=�6�   $��7��6�   $��1��6�   $��7��6�   $��0,0,0.001,0q�6�    5�      �� 5�      ! �� ColumnHeaderContainerStyle# [  6   .P�5�      �� $	 150��6%    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   $��
Номер��6@   5�      5�      �� 5�      $	 100��6%    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   ��6@   �� *TypeA+5�      5�      �� 5�      $	 100��6%    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   ��6@   �� *TypeB+5�      5�      �� 5�      $	 100��6%    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   ��6@   �� *TypeC+5�      5�      �� 5�      $	 150��6%    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   ��6@   �� *Sum+5�      5�      �� 5�      $	 150��6%    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   ��6@   �� *Ost+5�      5�      5�      5�      �� 5�   
   -   5        $��	BtnReport��5�      $��2��6:   #���  6N   $��
Отчет��6t   $��2��6�   $��9��6�   �� 5�   
   -   5        $��
BtnArrival��5�      $��2��6<   #���  6P   $��Поступление��6v   $��6��6�   $��9��6�   5�      5�      