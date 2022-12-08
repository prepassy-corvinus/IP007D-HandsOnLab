//fetch('/questions/5')
//    .then(response => response.json())
//    //.then(data => console.log(data)
//    .then(data => kerdesMegjelenites(data)
//);

//1. Jó válasz és kérdés ID meghatározására szolgáló változók
var jovalasz;
var questionId = 1;

//2. Kérdés megjelenítéséhez használt függvény
function kerdesMegjelenites(kerdes) {
    if (!kerdes) return;

    console.log(kerdes);

    document.getElementById("kérdés_szöveg").innerText = kerdes.question1
    document.getElementById("válasz1").innerText = kerdes.answer1
    document.getElementById("válasz2").innerText = kerdes.answer2
    document.getElementById("válasz3").innerText = kerdes.answer3

    jovalasz = kerdes.correctAnswer;

    if (kerdes.image) {
        document.getElementById("kép1").src = "https://kzgzdiag426.blob.core.windows.net/netcore/" + kerdes.image;
        document.getElementById("kép1").classList.remove("rejtett") 
    }
    else {
        document.getElementById("kép1").classList.add("rejtett")
    }
}

//3. Kérdés betöltéséhez használt függvény
function kerdesBetoltes(id) {
    fetch(`/questions/${id}`)
        .then(response => {
            if (!response.ok) {
                console.error(`Hibás válasz: ${response.status}`)
            }
            else {
                return response.json()
            }
        })
        .then(data => kerdesMegjelenites(data));

    document.getElementById("válasz1").classList.remove("jó", "rossz");
    document.getElementById("válasz2").classList.remove("jó", "rossz");
    document.getElementById("válasz3").classList.remove("jó", "rossz");
}

//4. Navigációra használt függvények
function elore(){
    questionId++;
    kerdesBetoltes(questionId)
}

function vissza() {
    questionId--;
    kerdesBetoltes(questionId)
}

//5. Választás ellenőrző függvény
function valasztas(v) {
    if (v != jovalasz) {
        document.getElementById(`válasz${v}`).classList.add("rossz");
        document.getElementById(`válasz${jovalasz}`).classList.add("jó");
    }
    else {
        document.getElementById(`válasz${jovalasz}`).classList.add("jó");
    }
}

//Az oldal betöltésekor beállított funkciók.
window.onload = function (e) {
    console.log("Az oldal betöltve...");
    document.getElementById("elore").onclick = elore;
    document.getElementById("vissza").onclick = vissza;
    kerdesBetoltes(questionId)
}
