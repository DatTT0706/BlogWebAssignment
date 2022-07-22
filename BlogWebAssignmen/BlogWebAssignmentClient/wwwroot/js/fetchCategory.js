// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//fetch data using javascript
const apiCategory = "https://localhost:5001/api/Category";

async function getData() {
    //fetch fetch data from api
    await fetch(apiCategory, {
        headers: {
            "Content-Type": "application/json"
        }, method: "get"
    }).then(res => res.json())
        .then(data => {
            displayCategory(data);
            displayCategoryNavbar(data);
        })
        .catch(e => console.error(e));
}

async function displayCategory(data = []) {
    let tagListContainer = await document.querySelector(".tags-list");
    await data.forEach((item) => {
        let a = document.createElement("a");
        a.href = ""
        a.className = "link-dark custom-tags";
        a.innerHTML = `<span>${item["title"]}</span>`;
        tagListContainer.appendChild(a);
    })
}

async function displayCategoryNavbar(data = []) {
    let ul = await document.getElementById("categoryList");
    await data.forEach((item) => {
        let li = document.createElement("li");
        li.className = "nav-item";
        li.innerHTML = `<a class="nav-link text-dark" 
href="http://localhost:8080">${item["title"]}</a>`;
        ul.appendChild(li);
    })
}

getData();

// Write your JavaScript code.
