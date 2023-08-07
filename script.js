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
var botonesSumar= document.getElementsByClassName('fa-solid fa-plus sumar-cantidad');
    for (var i=0; i<botonesSumar.length; i++){
        var button = botonesSumar[i];
        button.addEventListener('click', sumarCantidad);
    
    }
var botonesRestar= document.getElementsByClassName('fa-solid fa-minus restar-cantidad');
 for (var i=0; i<botonesRestar.length; i++){
    var button = botonesRestar[i];
    button.addEventListener('click', restarCantidad);
}
var agregaAlCarro = document.getElementsByClassName('boton-item');
for (var i=0; i<agregaAlCarro.length; i++){
    var button = agregaAlCarro[i];
    button.addEventListener('click', agregarAlCarroClicked);
}
document.getElementsByClassName('btn-pagar')[0].addEventListener('click', pagarClicked);
}
//funcino para sacar item del carro
function elimnaritemdelcarro(event){
    var botonClik = event.target;
    botonClik.parentElement.remove();
    //Actualizar el total
    actualizarTotal();
    ocultarCarro();
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
        var cantidad= parseInt(cantidadItem.value);
        //console.log (cantidad);
        total= total + (precio*cantidad);
    }
    total=Math.round(total*100)/100;
    document.getElementsByClassName('carro-precio-total')[0].innerText = '$'+ total.toLocaleString('es')+',00';
}
function ocultarCarro(){
    var carro = document.getElementsByClassName('carro-items')[0];
    if(carro.childElementCount == 0){
        var carrito=document.getElementsByClassName('carro')[0];
        carrito.style.marginRight= '-100%';
        carrito.style.opacity= '0';
        carroVer = false;
    var item= document.getElementsByClassName('contenedor-items')[0];
    item.style.width= '100%';
    }
}
function sumarCantidad(event){
    var botonClik= event.target;
    var selector =botonClik.parentElement;
    var CantidadActual= selector.getElementsByClassName('carro-cantidad')[0].value;
    CantidadActual++;
    selector.getElementsByClassName('carro-cantidad')[0].value= CantidadActual;
    actualizarTotal();
}
function restarCantidad(event){
    var botonClik= event.target;
    var selector =botonClik.parentElement;
    var CantidadActual= selector.getElementsByClassName('carro-cantidad')[0].value;
    CantidadActual--;
    if (CantidadActual>=1){
    selector.getElementsByClassName('carro-cantidad')[0].value= CantidadActual;
    actualizarTotal();
}
}
function agregarAlCarroClicked(event){
    var botonClik= event.target;
    var item = botonClik.parentElement;
    var titulo = item.getElementsByClassName('titulo-item')[0].innerText;
    var precio = item.getElementsByClassName('precio-item')[0].innerText;
    var imagen = item.getElementsByClassName('img-item')[0].src;
    agregarItemAlCarrito(titulo, precio, imagen);
    HacerVisibleElCarro();
}
function agregarItemAlCarrito (titulo, precio, imagen){
    var item = document.createElement('div');
    item.classList.add('items');
    var itemsCarrito = document.getElementsByClassName('carro-items')[0];
    var nombreItemsCarro = itemsCarrito.getElementsByClassName('titulo-item');
    for (var i=0; i<nombreItemsCarro.length; i++){
        if(nombreItemsCarro[i].innerText == titulo){
            alert('Este producto ya esta en el carro');
            return;
        }
    }
    var itemesContenidoDelCarro =` <div class="compra-items">
    <img src="${imagen}" alt="" width="60px">
    <div class="compra-item-detalle">
        <span class="carro-items-titulo">${titulo}</span>
        <div class="selector-cantidad">
            <i class="fa-solid fa-minus restar-cantidad"></i>
            <input type="text" value="1" class="carro-cantidad" disabled>
            <i class="fa-solid fa-plus sumar-cantidad"></i>
        </div>
        <sapn class="carro-precio">${precio}</sapn>
    </div>
    <span class="bt-eliminar">
        <i class="fa-solid fa-trash"></i>
    </span>
</div>`
    item.innerHTML= itemesContenidoDelCarro;
    itemsCarrito.append(item); 
    item.getElementsByClassName('bt-eliminar')[0].addEventListener('click', elimnaritemdelcarro);
    var botonSUmar= item.getElementsByClassName('fa-solid fa-plus sumar-cantidad')[0];
    botonSUmar.addEventListener('click', sumarCantidad); 
    var botonRestar= item.getElementsByClassName('fa-solid fa-minus restar-cantidad')[0];
    botonRestar.addEventListener('click', restarCantidad);     
}
function pagarClicked(event){
    alert('Gracias por su compra');
    var CarroItems = document.getElementsByClassName('carro-items')[0];
    while (CarroItems.hasChildNodes()){
        CarroItems.removeChild(CarroItems.firstChild);
    }
    actualizarTotal(); 
    ocultarCarro();
}
function HacerVisibleElCarro(){
    carroVer = true;
    var carrito=document.getElementsByClassName('carro')[0];
    carrito.style.marginRight= '0';
    carrito.style.opacity= '1';
    var item= document.getElementsByClassName('contenedor-items')[0];
    item.style.width= '60%';
}
