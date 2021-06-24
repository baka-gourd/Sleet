import * as React from "react";
import {
    Collapse,
    Container,
    Navbar,
    NavbarBrand,
    NavbarToggler,
    NavItem,
    NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./index.css";

export default class NavMenu extends React.PureComponent<
    {},
    { isOpen: boolean }
> {
    public state = {
        isOpen: false,
    };

    public render() {
        return (
            <header>
                <Navbar
                    className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3 bg-dark"
                    dark
                >
                    <Container>
                        <NavbarBrand tag={Link} to="/">
                            Sleet
                        </NavbarBrand>
                        <NavbarToggler onClick={this.toggle} className="mr-2" />
                        <Collapse
                            className="d-sm-inline-flex flex-sm-row-reverse"
                            isOpen={this.state.isOpen}
                            navbar
                        >
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink
                                        tag={Link}
                                        className="text-white"
                                        to="/"
                                    >
                                        首页
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink
                                        tag={Link}
                                        className="text-white"
                                        to="/project"
                                    >
                                        项目
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink
                                        tag={Link}
                                        className="text-white"
                                        to="/counter"
                                    >
                                        Counter
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink
                                        tag={Link}
                                        className="text-white"
                                        to="/fetch-data"
                                    >
                                        Fetch data
                                    </NavLink>
                                </NavItem>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen,
        });
    };
}
