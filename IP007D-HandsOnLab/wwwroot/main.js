//fetch('/questions/5')
//    .then(response => response.json())
//    //.then(data => console.log(data)
//    .then(data => kerdesMegjelenites(data)
//);

var jovalasz;
var questionId = 3;

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
}

kerdesBetoltes(questionId)
