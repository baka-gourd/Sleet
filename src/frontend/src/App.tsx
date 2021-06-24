import React from "react";
import { Route } from "react-router";
import Layout from "./pages/Layout";
import Counter from "./pages/Counter";
import FetchData from "./pages/FetchData";
import Home from "./pages/Home";
import ProjectPage from "./pages/ProjectPage";

export default () => (
    <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <Route path="/project" component={ProjectPage} />
        <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
    </Layout>
);
