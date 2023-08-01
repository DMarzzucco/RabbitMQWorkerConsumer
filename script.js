//variables para mantener el estado del carro
var carroVer = false;

if (document.readyState== 'loading'){
    document.addEventListener('DOMContentLoaded', ready)
} else {
    ready();
}

function ready(){
    //funcion para boton de eliminar
    var botonDelet = document.getElementsByClassName ('bt-eliminar');
    for (var i =0; i<botonDelet.length; i++){
        var button = botonDelet[i];
        button.addEventListener('click', elimnaritemdelcarro);
    }
}
//funcino para sacar item del carro
function elimnaritemdelcarro(event){
    var botonClik = event.target;
    botonClik.parentElement.remove();
    //Actualizar el total
    actualizarTotal();
}
//function de datos para actualizar el carro
function actualizarTotal(){
    var contenderoCarro= document.getElementsByClassName('carro')[0];
    var carroitems = contenderoCarro.getElementsByClassName ('carro-items');
    var total= 0;
    for (var i=0; i<carroitems.length;i++){
        var produc=carroitems[i];
        var precioelem= produc.getElementsByClassName('carro-precio')[0];
        console.log (precioelem);
        var precio = parseFloat(precioelem.innerText.replace('$','').replace('.',''));
        //console.log(precio);
        var cantidadItem= contenderoCarro.getElementsByClassName('selector-cantidad')[0];
        var cantidad= cantidadItem.value;
        //console.log (cantidad);
        total= total + (precio*cantidad);
    }
    total=Math.round(total*100)/100;
    document.getElementsByClassName('carro-precio-total')[0].innerText = '$'+ total.toLocaleString('es')+',00';
}
