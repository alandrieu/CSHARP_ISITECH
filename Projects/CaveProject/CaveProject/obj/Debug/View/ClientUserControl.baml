   M S B A M L   `   `   `  ����  CaveProject(    "CaveProject.View.ClientUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � $��Stretch=�6   $��Stretch=�6)     � 	Resources  5	   
      RowHeadersWithId �� 
TargetType:  4System.Windows.Controls.Primitives.DataGridRowHeader �� Property �� Value��%_   &	        �� 5
      "  6-   .�5      ��  � �� 6,   �� *
IdClient+5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5         AutoGenerateColumns .  $��12q�5         AlternatingRowBackground
 �����   RowHeaderStyle# [  5         HeadersVisibility$	 All=�5         CanUserAddRows . "	   VerticalScrollBarVisibility$
	 Auto=�5      $
   HorizontalScrollBarVisibility$

 Auto=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	FirstName��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	FirstName+6V     5      $ LastName��6B    6%   �� *
LastName+6B   5      5      5      