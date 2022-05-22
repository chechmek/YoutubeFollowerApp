import React, { Component } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from './component/Home';
import Other from './component/Other';

import './App.css';
import Navigation from './component/Navigation';

class App extends Component {
  render() {
    return (
      <Router>
        <Navigation />
        <div className="container">
          <Routes>
            <Route exact path='/' element={< Home />}></Route>
            <Route exact path='/other' element={< Other />}></Route>
          </Routes>
        </div>
      </Router>
    );
  }
}

export default App;