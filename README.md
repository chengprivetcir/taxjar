# taxjar

.net Core API demo 

1 Get Rates - HttpGet With Bearer Token

URL:https://localhost:44351/Tax/GetRates?Zip=30009

Response:
{
    "rate": {
        "city": "ALPHARETTA",
        "city_rate": "0.0",
        "combined_district_rate": "0.0075",
        "combined_rate": "0.0775",
        "country": "US",
        "country_rate": "0.0",
        "county": "FULTON",
        "county_rate": "0.03",
        "freight_taxable": true,
        "state": "GA",
        "state_rate": "0.04",
        "zip": "30009"
    }
}

2 Get Taxes - HttpPost With Bearer Token

URL:https://localhost:44351/Tax/GetTaxes

Request:
{
  "from_country": "US",
  "from_zip": "07001",
  "from_state": "NJ",
  "to_country": "US",
  "to_zip": "07446",
  "to_state": "NJ",
  "amount": 16.50,
  "shipping": 1.5
  
}

Response
{
    "tax": {
        "amount_to_collect": 1.19,
        "freight_taxable": true,
        "has_nexus": true,
        "jurisdictions": {
            "city": "RAMSEY",
            "country": "US",
            "county": "BERGEN",
            "state": "NJ"
        },
        "order_total_amount": 18,
        "rate": 0.06625,
        "shipping": 1.5,
        "tax_source": "destination",
        "taxable_amount": 18
    }
}
