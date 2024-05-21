import { useState } from "react"

function Home() {
    const [valueIm, setValueIm] = useState<number>(0)
    const plus = ({ }) => {
        setValueIm(preValue => preValue + 1)
    }

    const rest = ({ }) => {
        if (valueIm > 0) {
            setValueIm(prevValue => prevValue - 1)
        }
    }
    return (
        <>
            <section className="flex flex-col w-full h-screen justify-center items-center">
                <div>
                    <span>This is the house </span>
                    <h1 className="">THE HOUSSSSS</h1>
                </div>
                <div>
                    <button className="m-2 p-2 border  text-xl" onClick={rest}>-</button>
                    <input className="w-20 h-20 text-center" type="text" value={valueIm} readOnly />
                    <button className="m-2 p-2 border  text-xl" onClick={plus}>+</button>
                </div>
            </section>
        </>
    )
}
export default Home;