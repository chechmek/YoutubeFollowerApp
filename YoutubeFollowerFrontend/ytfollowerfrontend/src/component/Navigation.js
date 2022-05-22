import React from 'react';

import { Button, Navbar, Nav, NavItem, NavDropdown, MenuItem } from 'react-bootstrap';

function Navigation () {
    
        return <Navbar bg="dark" variant="dark">
       <div className='container'>
        <Navbar.Brand href="/">Home</Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link href="/other">Other</Nav.Link>
        </Nav>
        </div>
      </Navbar>
      
        
}
export default Navigation;