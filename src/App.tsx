import { BrowserRouter as Router, Routes, Route } from "react-router-dom"
import { Footer, Header } from "./components"
import { Home, Store } from "./page"

function App() {

  return (
    <Router>
      <Routes>
        <Route path="/" element={
          <>
            <Header />
            <Home/>
            <Footer />
          </>
        } />
        <Route path="/store" element={
          <>
            <Header />
            {/* <Store /> */}
            <Store/>
            <Footer />
          </>
        } />

      </Routes>
    </Router>
  )
}

export default App
