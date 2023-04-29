# Recharge and battery monitoring system
This is a simple system for capturing voltage and current events. Applicable for any Internet things that control the power supply of devices. 

## User stories

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

- 'Id': unique device identifier. Required field.
- 'V': voltage. Required field.
- 'I': current. Not required field. Default 0.
- 'VC': voltage in the charger circuit.
        Typically used to indicate that a charger is present but not connected to the battery circuit.
        Not required field. Default 0.
- 'DT': DateTime. Not required field. Default current Date Time.
- 'S': Event status. Not required field. Default 0.

## Endpoints

The following endpoints are available in the API
- 'PUT /api/data/putdata?Id=id&V=v' simple format for sending data
- 'GET /api/data/getdata?Id=id&From=data' simple format for get data
