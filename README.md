# Weekly Mini-project "Asset Tracker"

Create and track objects with several properties and mark objects based on time until End-of-life.

4 Office sites with 4 Devices each are included as samples with dates ranging between 1980-12-11 and 2027-01-08.
Currencies are retrieved from the European Central Bank and currencies in the app are converted upon display.
Prices are set to the same values between Offices to display the currency conversion.

## Functions:

### Add
Create new devices and input into the selected office.

### List
List the devices of the selected office, alternatively list *all* offices and their devices.

### Remove
Remove selected device from selected office via indexed list.


## Structure
I decided to use an interface to control device implementation due to my devices having no methods they need to inherit.

### AssetManager Class
Static class due to it being more of a tool than an object, plus accessibility concerns. It contains the methods for the control loops.

### Office Class
Contains its own List of Devices and manages the *actual* adding and removal of its own entries. 
Also contains it's own method for listing its devices.

### IDevice 
File also contains the declaration for the Enumerable **DeviceType** used in Computer and Phone classes

### CurrencyConverter Class
Static class due to it being a tool and needing accessibility. Gathers and creates the incoming Envelope object containing all currency rates.

### Envelope Class
Containing object for the currency rates.