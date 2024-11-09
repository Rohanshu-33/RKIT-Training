$(document).ready(function () {

    let availableCountries = ["INDIA", "USA", "UK", "RUSSIA"]
    let countryToCode = {
        "INDIA": "in",
        "USA": "us",
        "UK": "uk",
        "RUSSIA": "ru",
    }
    // let userFilters = JSON.stringify(localStorage.getItem("filters")) || []
    let userFilters = JSON.parse(localStorage.getItem("filters")) || []
    let country = localStorage.getItem("Country")
    if (!country) {
        country = "USA"
    }
    $("#countries").val(country)

    $.each(userFilters, function (index, value) { 
        if(value !== "general"){   
            $(`#${value}`).css("background-color", "#a198de")
            .css("color", "white")

            $(`#s-${value}`)
            .css("color", "rgb(151, 12, 200)").css("text-decoration", "underline")

        }
    });

    $("#countries").change(function (e) {
        e.preventDefault()
        country = $(this).val().toUpperCase()

        // country out of range
        if (!availableCountries.includes(country)) {
            $(this).val("")
            alert("Please select a valid country.")
            $(this).focus()
        }

        // entered country is correct.
        console.log(country)
        localStorage.setItem("Country", country)
        fetchNews()

    })

    // filter button toggle
    $(".btn-filters").click(function () {
        const filterName = $(this).val()

        if (userFilters.includes(filterName)) {
            //reset
            userFilters = userFilters.filter((fName) => fName !== filterName)
            $(this).css("background-color", "white")
            .css("color", "black")
        }
        else {
            userFilters = userFilters.filter((fName) => fName !== "general")
            userFilters.push(filterName)
            $(this).css("background-color", "#a198de")
                .css("color", "white")
        }
        console.log(userFilters)
        localStorage.setItem("filters", JSON.stringify(userFilters))
        fetchNews()
    })

    // filter span toggle

    $(".span-filters").click(function() {
        const filterName = $(this).text().toLowerCase()
        if(userFilters.includes(filterName)){
            userFilters = userFilters.filter((fName) => fName !== filterName)
            $(this).css("color", "black").css("text-decoration", "none")
        }
        else{
            userFilters = userFilters.filter((fName) => fName !== "general")
            userFilters.push(filterName)
            $(this).css("color", "rgb(151, 12, 200)").css("text-decoration", "underline")
        }
        console.log(userFilters)
        localStorage.setItem("filters", JSON.stringify(userFilters))
        console.log("phone view");
        fetchNews()
    })


    // fetch news and show in cards
    function fetchNews() {
        console.log("Fetching news...")
        const countryCode = countryToCode[country]
        // const API_KEY = "461dda6d493047c3afbdbc9be7850b68"
        const API_KEY = "a412525b23d842bdbc032e0a7045a358"

        if(userFilters.length===0){
            userFilters.push("general")
        }
        
        // array to store all promises from AJAX requests
        const promises = userFilters.map((filter) => {
            return $.ajax({
                type: "GET",
                url: `https://newsapi.org/v2/top-headlines?country=${countryCode}&category=${filter}&apiKey=${API_KEY}`
            }).then(
                response => response.articles,
                error => {
                    console.log("Unable to fetch news for category:", filter)
                    return []
                }
            )
        })
    
        $.when(...promises).then((...responses) => {
            const newsArrayResponse = responses.flat()
            displayNews(newsArrayResponse)
        })
    }    

    // display news on right side
    function displayNews(newsArray) {
        console.log("length of response : ", newsArray.length)
        $(".right").empty()
        newsArray.forEach((news, key) => {
            
            const title = news.title ? news.title.substring(0, 33) + "..." : "Title not available."
            const description = news.description ? news.description.substring(0, 70) + '...' : "Description not available."
            
            $(".right").append(`
            <div class="card w-100 mt-2 mb-3" style="cursor: pointer;" 
            onclick='showNewsOnMainArea(${JSON.stringify(news)})'>
            <div class="card-body">
            <h5 class="card-title">${title}</h5>
            <h6 class="card-subtitle">By ${news.author || "Unknown author"}</h6>
            <p class="card-text">${description}</p>
            <a href="${news.url}" target="_blank" class="btn btn-primary">See More</a>
            </div>
            </div>`)
        })
        showNewsOnMainArea(newsArray[0])
    }

    setTimeout(() => {
        fetchNews()
    }, 100)

})

function showNewsOnMainArea(news){
    console.log("Clicked.\n",news)
    $(".main-area").html(`
        <h3 style="overflow: hidden;">${news.title || "Title not available"}</h3>
        <h6 style="overflow: hidden;">By ${news.author || "Unknown author"}</h6>
        <img src=${news.urlToImage} class="img-thumbnail rounded mb-2"/>
        <h6 style="overflow: hidden;">Source: ${news.source.name}</h6>
        <p>${news.content ? news.content.substring(0, news.content.indexOf("[+")) : "Full content not available."}</p>
        <a href="${news.url}" target="_blank" class="btn btn-primary mt-3">Read Full Article</a>
    `)
}