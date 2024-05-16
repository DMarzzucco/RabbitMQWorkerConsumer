import express from "express";

const app = express()
app.use(express.json())

const PORT = 3000

app.get('/', (_req, res) => {
    console.log("conectado")
    res.send("enviado")
})

app.listen(PORT, () => {
    console.log(`server running on port ${PORT}`)
})