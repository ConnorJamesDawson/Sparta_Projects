function greeting() {
    window.alert("Good morning!")
    document.getElementById("greeting").innerText = "Oh, and if I don't see ya"
    console.log("Good afternoon, good evening and good night!")
}



function changeText() {
    let paragraph = document.getElementById("new-paragraph")

    if (paragraph) {
        paragraph.remove()
    }

    paragraph = document.createElement("p")
    paragraph.id = "new-paragraph"
    let textNode = document.createTextNode(actor.getFullName())
    paragraph.appendChild(textNode)
    document.getElementById("title-container").appendChild(paragraph)
}

let height = 24
const INCH_TO_CM = 2.54

document.write("<br>" + height * INCH_TO_CM)

const characters = []
characters.push("Truman Burbank")
characters[1] = "Ace Ventura"

const actor = {
    firstName: "Jim",
    lastName: "Carey",



    getFullName() { return this.firstName + " " + this.lastName }
}

console.log(actor.getFullName())