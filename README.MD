# Recharge and battery monitoring system
This is a simple system for capturing voltage and current events. 
Applicable for any Internet things that control the power supply of devices. 

## User Stories

    As a user, I want to be able to collect current data on voltage and current in the battery circuit
    As a user, I want to be able to record events and date time of events
    As a user, I want to be able to collect data only for my device
    As a user, I want to be able to generate reports
    As a user, I want to be able to receive event notifications
    As a user, I want to be able to change notification subscription

## Events status

- 'Default=0' Assigned to any entry unless explicitly specified
- 'Alarm=1' Usually applied if voltages or currents are above/below allowable values
- 'LoadOfChargeOf=2' Charger and load circuit are disconnected. Battery at idle
- 'LoadOnChargeOf=3' Load on, charger off
- 'LoadOnChargeOn=4' Load on, charger on
- 'LoadOfChargeOn=5' Load off, charger on

## Data Fields
Datas has the following fields:
- 'DeviceId': unique device identifier. Required field.
- 'Voltage': voltage. Required field.
- 'Current': current. Not required field. Default 0.
- 'VoltageCharger': voltage in the charger circuit.
    Typically used to indicate that a charger is present but not connected to the battery circuit.
    Not required field. Default 0.
- 'DateTime': DateTime. Not required field. Default current Date Time.
- 'Status': Event status. Not required field. Default 0.

## Endpoints

The following endpoints are available in the API:
- 'PUT /api/data/putdata' simple format for sending data
- 'GET /api/data/getdata?Id=id&From=data' simple format for get data

## Solution scheme

Description of the projects included in the solution.
- 'BatteryMonitorApp.WebApi' - provides interaction with the user (devices). 
    Provides API access. Returns data representations.
- 'BatteryMonitorApp.WebApp' - Not implemented yet. Should provide an API solution
    and Front End for data visualization.
- 'BatteryMonitorApp.Contracts' - is responsible for processing the data received 
    from the views, implements all the necessary logic, interacts with the database 
    and passes the processing result to the view. Implements business logic.
- 'BatteryMonitorApp.Domain' - responsible for storing data in the database. 
    Contains repositories, data models.
- 'BatteryMonitorApp.PhysicalDeviceEmulator' - emulates the operation of a real device. 
    Provides a lot of physical data.
- 'BatteryMonitorApp.UnitTests' and 'BatteryMonitorApp.IntegrationTests' - 
    appropriate solution tests