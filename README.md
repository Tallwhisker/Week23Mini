# Weekly Mini-project "Asset Tracker"

Create and track objects with several properties and mark objects based on time until End-of-life.

4 Office sites with 4 Devices are included as samples with dates ranging between 1980-12-11 and 2027-01-08.
Currencies are retrieved from the European Central Bank and currencies in the app are converted upon display.

## Functions:

### Add
Create new devices and input into the selected office.

### List
List the devices of the selected office, alternatively list *all* offices and their devices.

### Remove
Remove selected devices from selected office via indexed list.


## Structure
I decided to use an interface to control device implementation due to my devices having no methods they need to inherit.

### AssetManager class
Static class due to it being more of a tool than an object, plus accessibility concerns. It contains the methods for the control loops.

### Office class
Contains its own List of Devices and manages the *actual* adding and removal of its own entries. 
Also contains it's own method for listing its devices.

### IDevice subclasses (Phone, Computer)
IDevice contains enumerable, used for organizing the devices.

### CurrencyConverter class
Static class due to it being a tool and needing accessibility. Gathers and creates the incoming Envelope object containing all currency rates.

### Envelope
Containing object for the currency rates.