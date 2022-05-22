import React,{Component} from "react";
import { NavLink } from "react-bootstrap";
import { Navbar, Nav } from "react-bootstrap";

const Navigation = () => {
    
        return(
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                        Main
                    </NavLink>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/other">
                        Other channels
                    </NavLink>
                </Nav>
                </Navbar.Collapse>

            </Navbar>
            
        )
    }

export default Navigation;