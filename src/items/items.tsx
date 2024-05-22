import React from "react"
import { Link } from "react-router-dom"

interface HeaderProps {
    title: string,
    path: string
}
export const LinkHead: React.FC<HeaderProps> = ({ title, path }) => {
    return (
        <Link to={path}>
            <p>{title}</p>
        </Link>
    )
}

export const ErrorAuth: React.FC = ({ }) => {
    return (
        <div className=
            "bg-red-900 absolute text-white p-3 text-center rounded-xl border border-red-300 ">
            Auth Error
        </div>

    )
}
export const PassAuth: React.FC = ({ }) => {
    return (
        <div className=
            "bg-green-900 absolute text-white p-3 text-center rounded-xl border border-green-300 ">
            <b>PASS AUTH</b>
        </div>

    )
}
interface btnPr {
    click: () => void;
    title: string;
}
export const Ebtn: React.FC<btnPr> = ({ click, title }) => {
    return (
        <>
            <button className="m-2 p-2 border text-xl"
                onClick={click}>
                <b>{title}</b>
            </button>
        </>

    )
}
// componentes de compra
interface PropItemStore {
    title: string;
    src: string;
    price: number;
    click: () => void;
}
export const ItemsStore: React.FC<PropItemStore> = ({ title, src, price, click }) => {
    return (
        <div>
            <span>{title}</span>
            <img src={src} alt="" />
            <span>{price}</span>
            <button onClick={click}></button>
        </div>
    )
}