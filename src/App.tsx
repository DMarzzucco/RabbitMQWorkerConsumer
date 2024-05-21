import { BrowserRouter as Router, Routes, Route } from "react-router-dom"
import Home from "./page/home"
import { Footer, Header } from "./components"

function App() {

  return (
    <Router>
      <Routes>
        <Route path="/" element={
          <>
            <Header />
            <Home />
            <Footer />
          </>
        } />
      </Routes>
    </Router>
  )
}

export default App
