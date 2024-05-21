import React from "react"
import { Link } from "react-router-dom"

interface HeaderProps {
    title: string,
    path: string
}
export const LinkHead:React.FC <HeaderProps> = ({title, path}) =>{
    return (
        <Link to={path}>
            <p>{title}</p>
        </Link>
    )
}