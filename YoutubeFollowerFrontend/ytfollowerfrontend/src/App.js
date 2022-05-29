import React, { Component } from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from './component/Home';
import Other from './component/Other';
import Statistics from './component/Statistics';
import ChannelById from './component/ChannelById';

import './App.css';
import Navigation from './component/Navigation';
import CommentsByWord from './component/CommentsByWord';

class App extends Component {
  render() {
    return (
      <div className='bg'>
      <Router>
        <Navigation />
        <div className="container" style={{marginTop:'50px'}}>
          <Routes>
            <Route exact path='/' element={< Home />}></Route>
            <Route exact path='/other' element={< Other />}></Route>
            <Route exact path='/channel/:id' element={< ChannelById />}></Route>
            <Route exact path='/statistics/:id' element={< Statistics />}></Route>
            <Route exact path='/commentsbyword/:id/:word' element={< CommentsByWord />}></Route>
          </Routes>
        </div>
      </Router>
      </div>
    );
  }
}

export default App;