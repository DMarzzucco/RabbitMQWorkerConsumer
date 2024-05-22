import { ChangeEvent, useState } from "react"
import { Ebtn, ErrorAuth, PassAuth } from "../items/items";
import { useNavigate } from "react-router-dom";

function Home() {
    const [valueIm, setValueIm] = useState<number>(0)
    const [menu, setMenu] = useState<boolean>(false)
    const [auth, setAuth] = useState<string | number>();
    const [error, setError] = useState<boolean>(false);
    const [authPass, setAuthPass] = useState<boolean>(false);
    const nav = useNavigate();


    const TakeAuth = (event: ChangeEvent<HTMLInputElement>) => {
        setAuth(event.target.value);
    }

    const showMenu = () => { setMenu(!menu) }
    const plus = () => { setValueIm(preValue => preValue + 1) }

    const rest = () => {
        if (valueIm > 0) {
            setValueIm(prevValue => prevValue - 1)
        }
    }
    // password
    const pass: string = 'monto12';
    const Authenticator = ({ }) => {

        if (auth === pass) {
            console.log('es correcto')
            setAuthPass(true);
            setTimeout(() => setAuthPass(false), 500);
            setAuth('');
            nav('/store');
        }
        else {
            setError(true)
            setTimeout(() => setError(false), 500);
            setAuth('');
        }
    }
    return (
        <>
            <section className="flex flex-col w-full h-screen justify-center items-center">
                <div>
                    <span>This is the house </span>
                    <h1 className="">THE HOUSSSSS</h1>
                </div>
                <div className=" flex flex-row justify-center items-center m-4 p-2">
                    <Ebtn click={rest} title={"-"} />
                    <input  className="w-20 h-20 text-center rounded-full" type="text" value={valueIm} readOnly />
                    <Ebtn click={plus} title={"+"} />
                </div>

                <div className="flex flex-col justify-center items-center">
                    {!menu ?
                        <>
                            <span>Para entrar a la pagina darle aqui</span>
                            <button onClick={showMenu}>INGRESAR</button>
                        </> : null
                    }
                    {menu ?
                        <div className="flex flex-col justify-center items-center">
                            <input className="text-center"  type="password" placeholder="key" value={auth || ''} onChange={TakeAuth} />
                            {error ? <ErrorAuth /> : null}
                            {authPass ? <PassAuth /> : null}
                            <button onClick={Authenticator}>INICIAR</button>

                        </div>
                        : null}
                </div>
            </section>
        </>
    )
}
export default Home;