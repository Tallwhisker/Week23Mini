# Weekly Mini-project "Asset Tracker"

Create and track devices with several properties and mark them based on time until End-of-life.

4 Office sites with 4 Devices each are included as samples with dates ranging between 1980-12-11 and 2027-01-08.
Currency rates are retrieved from the European Central Bank and currencies in the app are converted upon display.
Price values of devices are set to the same values between Offices to display the currency conversion.

## Functions:

### Add
Select office via indexed list and then create devices via repeating input loop.

### List
Select an office via indexed list or "all" to list all offices and their devices' information.

### Remove
Select an office via indexed list and then again select the device you wish to remove with its own index.


## Structure
I decided to use an interface to control device classes because there were no methods needed for the device objects.

### AssetManager Class
Static class due to it being a tool that I want accessible. It contains the methods for the Function loops.

### Office Class
Contains a private list of devices and the methods required to manipulate and display this list.

### IDevice 
Interface for assuring that any implemented devices follow requirements.
IDevice.cs also holds the enum DeviceTypes used for organizing the lists.

### Phone, Computer Class
Currently implemented devices

### CurrencyConverter Class
Static class due to it being a tool that I want accessible. Requests and creates the Envelope object containing all currency rates.

### Envelope Class
Containing object for the currency rates.
