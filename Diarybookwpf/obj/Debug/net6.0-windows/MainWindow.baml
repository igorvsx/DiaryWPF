   M S B A M L   `   `   `  ????G  CDiarybookwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DiarybookwpfDiarybookwpf  5   	       Diarybookwpf.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Diarybookwpf     5   	     ? Title$  
MainWindow??5   	   $	??400??6   $	??795??6)   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      $
??0.5* ?6   ?? 5      $??2* ?6   .+?5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 
datePicker??5   A   $??35??6   $??Center=?6$   $??2??6?   $??Center=?6?   $	??575??6?   ?? 5   
   -   5         ??Name$ 	notesList??5   .   $??25??6   $??1??6!   $??2??6?   ??6o   ?? *Items+6?   ?? 5   
   $??30??6   $??0??6#   $??2??63   $??2??6G   $
??Wrap=?6T   $??Center=?6h   $??Center=?6?   $??18(?6?   ?? 6?    ? Language$ ru-ru?6?   $,?&Информация о заметке??6?   6?   ?? 5   
   $??35??6   $??3??6#   $??0??60   $??Center=?6@   $??Center=?6]   $
??Wrap=?6x   $??Название??6?   $??16(?6?   ?? 5   
   $??35??6   $??4??6#   $??0??60   $
??Wrap=?6@   $??Center=?6T   $??Center=?6o   $??Описание??6?   $??16(?6?   ?? 5   
   -   5         ??Name$ 	noteTitle??5   {   $??1??6   $??Center=?6"   $??Center=?6?   $??3??6Z    ?? TextWrapping$
 Wrap=?6g   $?? ??6?   $	??590??6?   $??35??6?   ?? 5   
   -   5        $ noteDescription??5   `   $??1??6   $??Center=?6"   $??4??6?   $
 Wrap=?6L   $?? ??6y   $??Center=?6?   $	??590??6?   $??34??6?   ?? 5   
   -   5         ??Name$ CreateButton??5   2   $??5??6   $??2??6   $??Создать??6H   $??Center=?6u   $??35??6?   ?? 5    
   -   5        $ UpdateButton??5    2   $??6??6   $??2??6   $??Обновить??6H   $??35??6v   $??Center=?6?   ?? 5!   
   -   5        $ DeleteButton??5!   2   $??7??6   $??2??6   $??Удалить??6H   $??34??6u   $??Center=?6?   5=      5>      