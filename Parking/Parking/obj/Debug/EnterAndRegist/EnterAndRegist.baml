   M S B A M L   `   `   `  ����B  >Parking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Parking.ViewModelParking.ViewModel  5   	   +    %Parking.EnterAndRegist.EnterAndRegist   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   +localclr-namespace:Parking.ViewModel  5   	     � Title$  Parking��5	   	   $	��650��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�68   .��5
      � -   5         �Name$ RegEnter��5
      ���	#ffdadada.+�5   
   �� $	��400��6   $��15q�6    
�������$��Center=�6?    �� Padding$ 30q�6Z   $	��550��6g    �� CornerRadius$ 20��6v    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ Purple��63      ShadowDepth$ 0Q�6B   6T   ._�5      �� 
���� ��.@�5      �� ��5      �� 5      	 �� Orientation$	 
Horizontal=�6%   .+�5      A� $��10��6&   $��10��62   
���� ��6M   �� 5      $��3q�6(    $   MaterialDesignHeadline1TextBlock#���   63   $��16(�6n   $��Times New Roman)�6|   
Вход6�   5      ��5      �� 5      .+�5      �� $��30(�6(   $��Center=�66   $��	0 20 0 20q�6S   !Добро Пожаловать5      �� 5      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Введите Email��6E    % !MaterialDesignFloatingHintTextBox#��[ 6t   $��0 0 0 15q�6�   ��6&   �� *EmailforEnter+6�   �� 5      $��11(�6(   
�������Введите пароль6X   �� 5      $��Webdings)�6G   #��[ 6]   $��0 0 0 5q�6�   ��6&   �� *PasswrdforEnter+6�   � 5      $��0 0 0 20q�6#   .+�5    "   �� $��
Войти��6)   $��16(�69   ��6G   �� *enter+6c   5!      5"      5$      �� 5%      ��5&      �� 5'      $	 
Horizontal=�6%   .+�5(      A� $��10��6&   $��10��62   
���� ��6M   �� 5)      $��3q�6(      MaterialDesignBody1TextBlock#��[ 63   $��16(�6i   $��Times New Roman)�6w   Регистрация6�   5*      ��5,      �� 5-      .+�5.      �� $��30(�6(   $��Center=�66   $��	0 20 0 20q�6S   Заполните поля6v   �� 5/      $6
 0Введите Email(пример vasya@mail.ru)��6=   #��[ 6�   $��0 0 0 10q�6�   ��6&   �� *Email+6�   �� 50      $#
 Введите Фамилию��6C   #��[ 6t   $��0 0 0 10q�6�   ��6&   �� *
Secondname+6�   �� 51      $
 Введите Имя��6A   #��[ 6n   $��0 0 0 10q�6�   ��6&   �� *	Firstname+6�   �� 52      $L
 FВведите номер телефона(пример +375297586413)��6>   #��[ 6�   $��0 0 0 20q�6�   ��6&   �� *Mobile+6�   �� 53      $��10(�6(   
�������Введите пароль6X   �� 54      $��Webdings)�6@   #��[ 6V   $��0 0 0 5q�6�   ��6&   �� *
Password+6�   �� 55      $��10(�6(   
�������!Повторите пароль6Z   �� 56      $��Webdings)�6C   #��[ 6Y   $��0 0 0 25q�6�   ��6&   �� *PasswordAgn+6�   � 57      $��0 0 0 20q�6#   .+�58   "   �� $*��$Зарегестрироваться��6)   $��16(�6F   ��6T   �� *regist+6q   59      5:      5<      5=      5>      5?      5@      