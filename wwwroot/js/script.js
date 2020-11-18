function addToBasketSingle(element) {
    var DishInfo = {
        "Type": element.parentNode.parentNode.id.split("_")[0],
        "Index": element.parentNode.parentNode.id.split("_")[1],
        "Size": null
    };
    try{
        if (DishInfo.Type == 'pizza') {
            var size = selectedSize(element.parentNode.parentNode);
            if (size != -1) {
                DishInfo.Size = size;
            }
            else {
                alert("Выберите размер!")
                return;
            }
        }
        // if everything breaks down, empty the basket
        if (sessionStorage['Basket'] == undefined) {
            sessionStorage['Basket'] = JSON.stringify([DishInfo]);
        }
        else {
            var Basket = JSON.parse(sessionStorage['Basket']);
            Basket.push(DishInfo);
            sessionStorage['Basket'] = JSON.stringify(Basket);
        }
    }
    catch(ex){
        sessionStorage.removeItem('Basket');
    }
    cartQuantity();
    console.log(sessionStorage['Basket']);
}

function addToBasketSeveral(element){

}

function cartQuantity(){
    document.getElementById("quantity").innerText = JSON.parse(sessionStorage['Basket']).length;
}

function selectedSize(element) {
    var radios = element.getElementsByTagName('input');
    for (let index = 0; index < radios.length; index++) {
        if (radios[index].checked) return radios[index].value;
    }
    return -1;
}