import React from "react";
import { LinkHead } from "../items/items";
const Header: React.FC = ({ }) => {
    return (
        <header>
            <div>
                <h1>logo</h1>
            </div>
            <ul>
                <LinkHead path={"/"} title={"home"}/>
                <LinkHead path={"/"} title={"salir"}/>
            </ul>
        </header>
    )
}

export default Header;