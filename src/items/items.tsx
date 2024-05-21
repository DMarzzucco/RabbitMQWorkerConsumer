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