   M S B A M L   `   `   `  ����I  EImportFilmToDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ImportMovieToDBImportMovieToDB  5   	        ImportMovieToDB.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ImportMovieToDB     5   	   -   5          � Title$  Import Film To Database��5   	   $��610.881��6)   $��879.67��6:   .��5	      � -   5         �Name$ importWindow��5	      .+�5
   
   �� -   5         ��Name$ openDB��5
      $��Open DataBase��6!   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $	��213��6   $��52��6�   $��18.667(�6�   6�   �� 5   
   -   5        $ readline��5      $��Read Next Line��6#   $
��Left=�6<   $��
628,10,0,0q�6W   $	��Top=�6k   $	��213��6�   $��52��6�   $��18.667(�6�   {�.  6�   �� 5   
   -   5         ��Name$ movieFullData��5      $
��Left=�6)   $	��102��6D   $��	10,67,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��684��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5   
   -   5        $ filmdetaildata��5      $
��Left=�6*   $	��399��6E   $��
10,174,0,0q�6R   $�� ��6f   $	��Top=�6n   $	��854��6�   $
 Auto=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   �� 5   
   -   5        $ DBname��5      $
��Left=�6"   $��27��6=   $��
504,35,0,0q�6I   $
 Wrap=�6]   $��MoviesDB��6q   $	��Top=�6�   $	��113��6�   �� 5   
   -   5         ��Name$ label��5      $��Database name��6   $
��Left=�67   $��
504,10,0,0q�6R   $	��Top=�6f   �� 5   
   -	   5        $ 
Servername��5      $
��Left=�6&   $��27��6A   $��
250,35,0,0q�6M   $
 Wrap=�6a   $��(localdb)\v11.0��6u   $	��Top=�6�   $	��228��6�   �� 5   
   -
   5        $ 
label_Copy��5      $��Server name��6$   $
��Left=�6:   $��
250,10,0,0q�6U   $	��Top=�6i   5      5      