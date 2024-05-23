import { useState } from "react";
import { ItemsStore } from "../items/items";

interface CartItem {
    name: string;
    price: number;
}

function Store() {
    const [cart, setCart] = useState<CartItem[]>([]);
    const [menuCarro, setMenuCarro] = useState<boolean>(false);

    const addToCart = (event: React.MouseEvent<HTMLButtonElement>) => {
        const button = event.currentTarget;
        const itemsName = button.getAttribute('data-name') || 'Uknown Item';
        const itemPrice = button.getAttribute('data-price');

        const price = itemPrice ? parseInt(itemPrice, 10) : 0;
        if (price > 0) {
            setCart((currentCart) => [
                ...currentCart, { name: itemsName, price: price },
            ])
            setMenuCarro(true)
        }
    }

    const Total = () => {
        return cart.reduce((total, item) => total + item.price, 0)
    };

    return (
        <>
            <section className="w-full h-screen flex flex-col justify-center items-center">
                <div>
                    <h1>Esta es la store</h1>
                </div>
                <div>
                    <div>
                        <h1>termo</h1>
                        <span>100</span>
                        <button data-name="termo" data-price="100" onClick={addToCart}>Agregar al carro</button>
                    </div>
                </div>
            </section>
            {menuCarro ?
                <div>
                    <h1>Cart</h1>
                    <p>Total: {Total()}</p>
                    <ul>
                        {cart.map((item, index) => (
                            <li key={index}>
                                {item.name} - {item.price}
                            </li>
                        ))}
                    </ul>
                </div> : null
            }
        </>
    )
}
export default Store;