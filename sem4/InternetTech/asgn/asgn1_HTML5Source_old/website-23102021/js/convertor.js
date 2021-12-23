const dropList = document.querySelectorAll("form select"),
  fromCurrency = document.querySelector(".from select"),
  toCurrency = document.querySelector(".to select"),
  input = document.querySelector("form input");

  //Getting Currencies of supported countries
for (let i = 0; i < dropList.length; i++) {
  for (let currency_code in country_currencies) {
    // MYR is selected by default To USD
    let selected =
      i == 0
        ? currency_code == "MYR"
          ? "selected"
          : ""
        : currency_code == "USD"
        ? "selected"
        : "";

    let optionTag = `<option value="${currency_code}" ${selected}>${currency_code}</option>`;
    // Drop down list options to select from are inserted here
    dropList[i].insertAdjacentHTML("beforeend", optionTag);
  }
  dropList[i].addEventListener("change", (e) => {
    countryFlags(e.target); // calling countryFlags with passing target element as an argument
    getExchangeRate();
  });
}

function countryFlags(element) {
  for (let code in country_currencies) {
    if (code == element.value) {
      // if currency code of supported-currencies is = to option value
      let imgTag = element.parentElement.querySelector("img"); // selecting img tag of specific drop-list
      // passing country code of a selected currency code in a img url
      imgTag.src = `images/${country_currencies[code]}.webp`;
    }
  }
}

window.addEventListener("load", () => {
  getExchangeRate();
});

input.addEventListener("input", () => {
  getExchangeRate();
});

const exchangeIcon = document.querySelector("form .icon");
exchangeIcon.addEventListener("click", () => {
  let tempCode = fromCurrency.value;
  fromCurrency.value = toCurrency.value; // passing TO currency code -> FROM currency code
  toCurrency.value = tempCode;
  countryFlags(fromCurrency); // calling countryFlags with passing select element (fromCurrency) of FROM
  countryFlags(toCurrency); // calling countryFlags with passing select element (toCurrency) of TO
  getExchangeRate();
});

//only this need editting
function getExchangeRate() {
  const exchangeRateTxt = document.querySelector("form .display-conversion");
  const exchangeRateTxt2 = document.querySelector("form .display-rate");
  
  let amountValue = input.value;
  // By default it is set to '1' in the input field
  if (amountValue == "" || amountValue == "0") {
    input.value = "1";
    amountValue = 1;
  }
  exchangeRateTxt.innerText = "Fetching latest rate...";
  let url = `https://v6.exchangerate-api.com/v6/a3bb9fc63fdae6c52bb81c7a/latest/${fromCurrency.value}`;
  // Getting the api response and processing it into a js obj, then passing that obj to another procedure.
  fetch(url)
    .then((response) => response.json())
    .then((result) => {
      let exchangeRate = result.conversion_rates[toCurrency.value]; // fetching the TO selected option from user
      let totalExchangeRate = (amountValue * exchangeRate).toFixed(2); // multiplying input value to the exchange rate requested
      exchangeRateTxt.innerText = "";
      exchangeRateTxt.insertAdjacentHTML("beforeend", `${amountValue} <span style="color:rgb(80, 80, 255);">${fromCurrency.value}</span> <span style="color: rgb(75, 87, 156);">=</span> ${totalExchangeRate} <span style="color: rgb(209, 52, 52);">${toCurrency.value}</span>`);
      exchangeRateTxt2.innerText = `Exchange rate: x${exchangeRate}`;
    })
    .catch(() => {
      // Since we are using API to fetch data, users might run into connection issues sometimes.
      exchangeRateTxt.innerText = "404, Couldn't fetch data!";
    });
}
