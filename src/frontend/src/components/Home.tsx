import * as React from "react";
import { connect } from "react-redux";
import ComponentCard from "./ComponentCard";

const Home = () => (
    <div>
        <h1>HomePage</h1>
        <ComponentCard
            imgUrl="https://avatars.githubusercontent.com/u/36119339?v=4"
            projectDescription="A shit game."
            projectName="Minecraft"
        />
    </div>
);

export default connect()(Home);
