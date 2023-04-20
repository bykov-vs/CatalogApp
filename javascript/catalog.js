

function searchWithFilters(){
    var filterGenres = new Array()
    var filterPublisher = new Array()
    var checkboxList = document.getElementsByClassName("genre-checkbox")
    for(var i=0; i < checkboxList.length; ++i){
        if(checkboxList[i].checked){
            filterGenres[i] = checkboxList[i].value;
        }
    }
    checkboxList = document.getElementsByClassName("publisher-checkbox")
    for(var i=0; i < checkboxList.length; ++i){
        if(checkboxList[i].checked){
            filterPublisher[i] = checkboxList[i].value;
        }
    }
    var request = new XMLHttpRequest()
    request.onreadystatechange = function(){
    if (request.readyState != 4) return;
        if (request.status != 200) {
            alert('Ошибка!')
        } else {
            displayBooks(JSON.parse(request.responseText))
        }
    }
    request.open('GET', './books/books.json', true)
    request.send()
    var objects = request.responseText
    if (filterGenres.length == 0 && filterPublisher == 0){
        displayBooks(objects)
        return
    }
    var result = new Array()
    for(var i=0; i < objects.length; ++i){
        if (filterGenres.contains(objects["genre"]) || filterPublisher.contains(objects["publisher"])){
            result.push(objects[i])
        }
    }
    displayBooks(objects)
}