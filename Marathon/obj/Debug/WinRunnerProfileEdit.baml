   M S B A M L   `   `   `  ����C  ?Marathon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MarathonMarathon  5   	   #    Marathon.WinRunnerProfileEdit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Marathon     5   	     � Title$0  *Marathon Skills 2016 - Edit runner profile��5   	   $	��600��6<   $	��800��6I    � WindowStartupLocation$ CenterScreen=�6U    � 	Resources 5	         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%v  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
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
   " ��6$   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � �� �#3d3d3d6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ 20(�6)   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      "	 ��6&   .R�5)      �� $
 border��6!   $ 10��61   #��z��6C   #��z��6o   #��z��6�    . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5C      �  � ColumnDefinitions 5D   
   �� 5E      $	��19* �6   �� 5F      $	��32* �6   �� 5G      $	��79* �6   �� 5H      $	��11* �6   �� 5I      $	��65* �6   �� 5J      $	��52* �6   �� 5K      $	��35* �6   �� 5L      $	��41* �6   �� 5M      $	��21* �6   �� 5N      $	��44* �6   �� 5O      $	��52* �6   �� 5P      $	��75* �6   �� 5Q      $	��89* �6   �� 5R      $	��17* �6   �� 5S      $	��32* �6   �� 5T      $	��16* �6   �� 5U      $	��54* �6   �� 5V      $	��27* �6   �� 5W      $	��19* �6   �� 5X      $	��12* �6    � RowDefinitions 5Z   
   �� 5[      $	��25* �6   �� 5\      $	��45* �6   �� 5]      $	��25* �6   �� 5^      $	��17* �6   �� 5_      $	��27* �6   �� 5`      $	��35* �6   �� 5a      $	��33* �6   �� 5b      $	��10* �6   �� 5c      $	��35* �6   �� 5d      $	��10* �6   �� 5e      $	��34* �6   �� 5f      $	��10* �6   �� 5g      $	��33* �6   �� 5h      $	��11* �6   �� 5i      $	��34* �6   �� 5j      $	��13* �6   �� 5k      $	��20* �6   �� 5l      $	��16* �6   �� 5m      $	��16* �6   �� 5n      $	��11* �6   �� 5o      $	��15* �6   �� 5p      $	��15* �6   �� 5q      $	��22* �6   �� 5r      $	��23* �6   �� 5s      $	��34* �6   .+�5u   
   �� $��Marathon Skills 2016��6   ���	#FF434347
�������$��35(�6Y   $
��Left=�6g   $��Center=�6�   $
��Bold"�6�   $��Arial)�6�   $��5��6�   $��3��6�   $��15��6�   �� 5v   
   $�� ��6   ���	#FF434347$��5��62   $��3��6F   �� 5w   
   -   5        $��BtnBack��5w      $��
Назад��66   $��1��6F   $��1��6V   #��� 
 6c   $��2��6�   �� 5x   
   -   5        $��LblTime��5x      $�� ��6   ���	#FF434347
�������$��20(�6T   $��Center=�6b   $��Center=�6�   $��Arial)�6�   $��24��6�   $��20��6�   �� 5y   
   $1��+Редактирование профиля��6   $��20(�61   $��Center=�6?   $��Center=�6a   $��Arial)�6�   $
��Bold"�6�   ���#3d3d3d$��2��6�   $��3��6�   $��6��6�   $��2��6�   �� 5z   
   $��Email:��6   $��Center=�6!   $��Right=�6C   $��15(�6f   $��1��6t   $��6��6�   $��2��6�   �� 5{   
   $��Имя:��6   $��Center=�6   $��Right=�6A   $��15(�6d   $��1��6r   $��8��6�   $��2��6�   �� 5|   
   $��Фамилия:��6   $��Center=�6#   $��Right=�6E   $��15(�6h   $��1��6v   $��10��6�   $��2��6�   �� 5}   
   $��Пол:��6   $��Center=�6   $��Right=�6A   $��15(�6d   $��1��6r   $��12��6�   $��2��6�   �� 5~   
   $ ��Дата рождения:��6   $��Center=�6)   $��Right=�6K   $��15(�6n   $��14��6|   $��3��6�   �� 5   
   $��Страна:��6   $��Center=�6"   $��Right=�6D   $��15(�6g   $��1��6u   $��16��6�   $��2��6�   $��2��6�   �� 5�   
   -   5        $��
CmbCountry��5�      $��4��6%   $��4��69   $��16��6I   $��2��6W   (  "System.Windows.Controls.DatePicker  5�   
   -   5        $��DateOfBirthPick��5�      $��4��6-   $��14��6=   $��4��6K   �� 5�   
   -   5        $��	CmbGender��5�      $��4��6$   $��4��68   $��12��6H   �� 5�   
   
���   �$��1q�6%   $��4��69   $��4��6M   $��10��6]   ._�5�      �� -   5        $��TxtLastName��5�       �� TextWrapping$
 Wrap=�6)   $
��Left=�6=   $��Center=�6�   $��15(�6�   $�� ��6�   5�      �� 5�   
   
���   �$��1q�6%   $��4��69   $��4��6M   $��8��6]   ._�5�      �� -   5        $��TxtFirstName��5�      $
 Wrap=�6*   $
��Left=�6?   $��Center=�6�   $��15(�6�   $�� ��6�   5�      �� 5�   
   $��Смена пароля��6   $��20(�6'   $��Center=�65   $��Center=�6W   $��Arial)�6{   $
��Bold"�6�   ���#3d3d3d$��11��6�   $��12��6�   $��4��6�   �� 5�   
   $���~Оставьте эти поля незаполненными, 
если вы не хотите изменять пароль��6   
�������$��Center=�6z   $��Center=�6�   $��15(�6�   $��10��6�   $��14��6�   $��8��6�   $��2��6  �� 5�   
   $��Пароль:��6   $��Center=�6"   $��Right=�6D   $��15(�6g   $��10��6u   $��17��6�   $��2��6�   $��2��6�   �� 5�   
   $ ��Повтор пароля:��6   $��Center=�6)   $��Right=�6K   $��15(�6n   $��10��6|   $��20��6�   $��2��6�   $��2��6�   �� 5�   
   
���   �$��1q�6%   $��5��69   $��12��6M   $��17��6^   $��2��6l   ._�5�      G� -   5        $��	PasswdBox��5�      $
��Left=�6+   $��Center=�6M   $��15(�6o   5�      �� 5�   
   
���   �$��1q�6%   $��12��69   $��20��6J   $��5��6X   $��2��6l   ._�5�      G� -	   5        $��ConfirmPasswdBox��5�      $
��Left=�62   $��Center=�6T   $��15(�6v   5�      �� 5�   
   -
   5        $��BtnSaveChanges��5�      $��3��6D   $��Сохранить��6X   $��2��6l   #��� 
 6|   $��21��6�   $��2��6�   �� 5�   
   -   5        $��3��5�   '   $��Отмена��6;   $��6��6L   #��� 
 6\   $��21��6�   $��2��6�   �� 5�   
   -   5        $��LblEmail��5�      $�� ��6    $��Center=�6+   $
��Left=�6M   $��15(�6o   $��4��6}   $��6��6�   $��4��6�   �� 5�   
   -   5        $��	BtnLogout��5�   K   $��4��6   #��� 
 6%   $��Logout��6u   $��13��6�   $��1��6�   �� 5�   
   
���   �$��1q�6%   $��4��69   $��13��6M   $��4��6^   $��4��6k   ._�5�      �� -   5        $��
ImgProfile��5�      5�      �� 5�   
   $��Фото файл:��6   $��Center=�6%   $��Center=�6I   $��20(�6k   $��10��6y   $��8��6�   $��2��6�   �� 5�   
   
���   �$��1q�6%   $��3��69   $��10��6M   $��10��6^   ._�5�      �� -   5        $��TxtPhotoFile��5�   (    �� 
IsReadOnly . $��15(�6<   $
��Left=�6J   
�������$��Center=�6~   $
 Wrap=�6�   $�� ��6�   5�      �� 5�   
   -   5        $��BtnFindPhoto��5�      $��5��6%   $��Просмотр...��69   #��� 
 6O   $��14��6v   $��10��6�   6�   5�      5�      