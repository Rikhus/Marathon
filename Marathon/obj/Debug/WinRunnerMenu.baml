   M S B A M L   `   `   `  ����C  ?Marathon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MarathonMarathon  5   	       Marathon.WinRunnerMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Marathon     5   	     � Title$(  "Marathon Skills 2016 - Runner menu��5   	   $	��600��64   $	��800��6A    � WindowStartupLocation$ CenterScreen=�6M    � 	Resources 5	         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%n  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ 20(�6)   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      "	 ��6&   .R�5)      �� $
 border��6!   $ 10��61   #��z��6C   #��z��6o   #��z��6�    . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5C      �  � ColumnDefinitions 5D   
   �� 5E      $	��19* �6   �� 5F      $	��86* �6   �� 5G      $	��25* �6   �� 5H      $	��53* �6   �� 5I      $	��39* �6   �� 5J      $	��22* �6   �� 5K      $
��138* �6   �� 5L      $	��23* �6   �� 5M      $
��136* �6   �� 5N      $	��64* �6   �� 5O      $	��43* �6   �� 5P      $	��54* �6   �� 5Q      $	��57* �6   �� 5R      $	��33* �6    � RowDefinitions 5T   
   �� 5U      $	��25* �6   �� 5V      $	��45* �6   �� 5W      $	��25* �6   �� 5X      $	��22* �6   �� 5Y      $	��47* �6   �� 5Z      $	��57* �6   �� 5[      $	��21* �6   �� 5\      $	��42* �6   �� 5]      $	��24* �6   �� 5^      $	��32* �6   �� 5_      $	��30* �6   �� 5`      $	��23* �6   �� 5a      $	��26* �6   �� 5b      $	��33* �6   �� 5c      $	��72* �6   �� 5d      $	��45* �6   .+�5f   
   �� $��Marathon Skills 2016��6   ���	#FF434347
�������$��35(�6Y   $
��Left=�6g   $��Center=�6�   $
��Bold"�6�   $��Arial)�6�   $��4��6�   $��3��6�   $��10��6�   �� 5g   
   $�� ��6   ���	#FF434347$��4��62   $��3��6F   �� 5h   
   -   5        $��BtnBack��5h      $��
Назад��66   $��20(�6F   $��1��6T   $��1��6d   $��2��6r   #��� 
 6�   �� 5i   
   -   5        $��LblTime��5i      $�� ��6   ���	#FF434347
�������$��20(�6T   $��Center=�6b   $��Center=�6�   $��Arial)�6�   $��15��6�   $��14��6�   �� 5j   
   $��Меню бегуна��6   $��Center=�6&   ���#3d3d3d$��25(�6_   $��4��6m   $��4��6}   $��6��6�   �� 5k   
   -   5        $��BtnRegisterForMar��5k      $��4��6J   $0��*Регистрация на марафон��6^   $��3��6   $��6��6�   $��2��6�   #��� 
 6�   �� 5l   
   -   5        $��
BtnResults��5l      $��4��6<   $!��Мои результаты��6P   $��8��6i   $��6��6y   $��2��6�   #��� 
 6�   �� 5m   
   -   5        $��BtnEditProfile��5m      $��4��6D   $1��+Редактирование профиля��6X   $��3��6y   $��9��6�   $��2��6�   #��� 
 6�   �� 5n   
   -   5        $��
BtnSponsor��5n      $��4��6<   $��Мой спонсор��6P   $��8��6f   $��9��6v   $��2��6�   #��� 
 6�   �� 5o   
   -   5        $��BtnContacts��5o      $��4��6>   $��Контакты��6R   $��3��6e   $��12��6u   $��2��6�   #��� 
 6�   �� 5p   
   -   5        $��	BtnLogout��5p      $��2��6:   $��Logout��6N   $��11��6_   $��1��6p   #��� 
 6}   5t      5u      