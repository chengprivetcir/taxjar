# taxjar

.net Core API demo 

1 Get Rates - HttpPost

URL:https://localhost:44351/Tax/GetRates

Request:
{
    "Zip":"05495-2086",
    "Street":"312 Hurricane Lane",
    "City":"Williston",
    "State":"VT",
    "Country":"US"
}

Response:
{
    "zip": "05495-2086",
    "state": "VT",
    "stateRate": 0.06,
    "county": "CHITTENDEN",
    "countyRate": 0.0,
    "city": "WILLISTON",
    "cityRate": 0.0,
    "combinedDistrictRate": 0.0,
    "combinedRate": 0.06,
    "freightTaxable": true,
    "country": "US",
    "name": null,
    "countryRate": 0.0,
    "standardRate": 0,
    "reducedRate": 0,
    "superReducedRate": 0,
    "parkingRate": 0,
    "distanceSaleThreshold": 0
}

2 Get Taxes - HttpPost
URL:https://localhost:44351/Tax/GetTaxes

Request:
{
  "fromAddress":  {
    "zip": "92093",
    "street": "9500 Gilman Drive",
    "city": "La Jolla",
    "state": "CA",
    "country":"US"
  },
  "toAddress":  {
    "zip": "90002",
    "street": "4627 Sunset Ave",
    "city": "Los Angeles",
    "state": "CA",
     "country":"US"
  },
  "amount": 15.0,
  "shipping": 1.5
}
Response
{
    "orderTotalAmount": 16.5,
    "shipping": 1.5,
    "taxableAmount": 15.0,
    "amountToCollect": 1.43,
    "rate": 0.095,
    "hasNexus": true,
    "freightTaxable": false,
    "taxSource": "destination",
    "exemptionType": null,
    "jurisdictions": {
        "country": "US",
        "state": "CA",
        "county": "LOS ANGELES COUNTY",
        "city": "LOS ANGELES"
    },
    "breakdown": null
}
