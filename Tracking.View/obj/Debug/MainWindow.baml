   M S B A M L   `   `   `  ����M  ITracking.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:Tracking.ViewModel;assembly=Tracking.ViewModelTracking.ViewModel  5   	   H DTracking.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Tracking.ViewTracking.View 5   	      Tracking.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   R	viewmodel<clr-namespace:Tracking.ViewModel;assembly=Tracking.ViewModel     5   	   -localclr-namespace:Tracking.View     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5      &    Tracking.ViewModel.MainViewModel   MainViewModel  BoolToVisibilityConverter��%:   &	        &	        5   
   6:   �� 5   
   6'   5      .��5      �  � DataContext 6   ��  �� Source# [   � ColumnDefinitions 5   
   �� 5      $��20 �6   6,   �� 5      6!   �� 5      $	��100 �6   6-   �� 5      6!   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      6   �� 5      $��20 �6   6*   .+�5   
   r� -   5        $��Loading��5      $��2��6&   $��0��66   $��Center=�6C   $��Center=�6`    r� Source$ IMG/Loading.gif?�5      $	��150��60   $	��300��6<    r� Stretch$ Uniform=�6I   y�5       �� *HasInstalled+ �� 	Converter# [ 5!      �� 5#   
   -   5        	 ��Name$	 RightButtons��5#      
������ 
������ $��1��6Z   $��2��6g   $��60��6w   $��50��6�   $	��Top=�6�   ��6�   �� *RightMulCommand+.��5$      �� 
 �� Orientation$
 
Horizontal=�6   .+�5%      �� $��IMG/rightarrows.png��6   $��Uniform=�65   5&      5'      �� 5(   
   -   5        $	 RightButton��5(      
������ 
������ $��1��6Y   $��2��6f   $��60��6v   $��50��6�   $��20,110,20,0q�6�   $	��Top=�6�   ��6�   �� *RightCommand+.��5)      �� $
 
Horizontal=�6   .+�5*      �� $��IMG/rightarrow.png��6   $��Uniform=�64   5+      5,      �� 5-   
   -   5        $	 
LeftButton��5-      
������ 
������ $��1��6X   $��2��6e   $��60��6u   $��50��6�   $��20,210,20,0q�6�   $	��Top=�6�   ��6�   �� *LeftCommand+.��5.      �� $
 
Horizontal=�6   .+�5/      �� $��IMG/leftarrow.png��6   $��Uniform=�63   50      51      �� 52   
   -   5        $	 LeftButtons��52      
������ 
������ $��1��6Y   $��2��6f   $��60��6v   $��50��6�   $��Bottom=�6�   ��6�   �� *LeftMulCommand+.��53      �� $
 
Horizontal=�6   .+�54      �� $��IMG/leftarrows.png��6   $��Uniform=�64   55      56      &   System.Windows.Controls.DataGrid  58   
   -   5        $��DGLeft��58   \   $��1��6   $��1��6       
IsReadOnly .     SelectionMode$ Extended=�6C   ��6j   �� *	TrackList+ �� SelectedItem 6�   �� *TrackSelected+5E        5G   
   -   5        $��DGRight��5G   \   $��1��6   $��3��6     .  $ Extended=�6C   ��6k   �� *TrackListdos+ 6�   �� *TrackDosSelected+5T      5W      5X      