async function displayCategoryNavbar(data = []) {
    let ul = await document.getElementById("categoryList");
    await data.forEach((item) => {
        let li = document.createElement("li");
        li.className = "nav-item";
        li.innerHTML = `<a class="nav-link text-dark" 
                asp-action="Index" asp-controller="Home">${item["title"]}</a>`;
        ul.appendChild(li);
    })
}


const apiCategory = "https://localhost:5001/api/Category";

async function getData() {
    //fetch fetch data from api
    await fetch(apiCategory, {
        headers: {
            "Content-Type": "application/json"
        }, method: "get"
    }).then(res => res.json())
        .then(data => {
            displayCategoryNavbar(data);
        })
        .catch(e => console.error(e));
}

getData();