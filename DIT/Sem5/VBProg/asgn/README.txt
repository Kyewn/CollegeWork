1. Import the database:
i. Open Microsoft SQL Server Management Studio (SSMS)
ii. Right-click on the "Databases" folder, click on "Import Data Tier Application"
iii. Follow the steps in the wizard to import the database file named "BookManager.bacpac"

2. Open the project:
i. Open Microsoft Visual Studio
ii. Locate, select and open the project "BookManager"

3. Change the server name to your SQL server name in the database connection string in these source code files:
-  DashboardDialogs folder
> DialogBookSearchSettings.vb
> DialogEditBook.vb
-  TrackOrdersDialogs folder
> DialogAddOrder.vb
> DialogEditOrder.vb
> DialogOrderSearchSettings.vb
-  ViewSalesDialogs folder
> DialogAddSale.vb
> DialogSaleSearchSettings.vb
-  ViewStocksDialogs folder
> DialogEditStock.vb
> DialogStockSearchSettings.vb
-  AddBook.vb
-  AddStock.vb
-  Dashboard.vb
-  TrackOrders.vb
-  ViewSales.vb
-  ViewStocks.vb

4. As a precaution, ensure that the project's Startup form is correct:
i. Click "Project" in the menu bar
ii. Select "BookManager Properties"
iii. In the "Application" tab, ensure that "Startup form" is set to "Layout"

5. Press the start button to run the program.

5.5 Unblock .resx files [CIRCUMSTANTIAL]:
If an error saying "Couldn't process file ***.resx due to its being in the Internet or Restricted zone...." is thrown when the program is run, some modifications need to be done to the .resx files in the project directory. 
i. Go to the BookManager folder where the project files reside in
ii. Right click and click on "Properties" for each of these .resx files:
-  CommonDialogs folder
> DialogAddCategory.resx
> DialogAddSupplier.resx
> DialogAddLocation.resx
-  DashboardDialogs folder
> DialogBookSearchSettings.resx
> DialogEditBook.resx
-  TrackOrdersDialogs folder
> DialogAddOrder.resx
> DialogEditOrder.resx
> DialogOrderSearchSettings.resx
-  ViewSalesDialogs folder
> DialogAddSale.resx
> DialogEditSale.resx
> DialogSaleSearchSettings.resx
-  ViewStocksDialogs folder
> DialogEditStock.resx
> DialogStockSearchSettings.resx
-  AddBook.resx
-  AddStock.resx
-  Dashboard.resx
-  TrackOrders.resx
-  ViewSales.resx
-  ViewStocks.resx
-  Layout.resx
iii. Check the "Unblock" option in the each file's "Properties" window to unblock the files one by one.