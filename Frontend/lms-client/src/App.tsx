import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import { Route, Routes, useNavigate } from 'react-router-dom'
import BookList from './BookList'
import { Button } from 'antd'

function App() {
  const [count, setCount] = useState(0)
  const navigate = useNavigate();

  return (
    <>
    <Routes>
        <Route path="/books" element={<BookList />} />
    </Routes>
    <h1>Menus </h1>
    <br></br>
    <Button
        type="primary"
        size="large"
        style={{width:"30%"}}
        onClick={() => navigate("/books")}
    >
        View Books
    </Button>
    <br></br>
    </>
        
    );
}

export default App
