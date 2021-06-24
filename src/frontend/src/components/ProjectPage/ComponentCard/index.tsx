import React, { Component } from "react";

type ComponentCardProps = {
    imgUrl: string;
    projectName: string;
    projectDescription: string;
} & typeof ComponentCard.defaultProps;

export default class ComponentCard extends Component<ComponentCardProps> {
    static defaultProps = {
        imgUrl: "./favicon.ico",
        projectName: "Default",
        projectDescription: "No description.",
        isLock: false,
    };

    state = { isLock: false };

    lock() {
        this.setState({ isLock: true });
    }

    unlock() {
        this.setState({ isLock: false });
    }

    componentDidMount() {
        if (this.props.isLock) {
            this.lock();
        }
    }

    render() {
        return (
            <div
                className="card mr-2 ml-2 mt-2 mb-2"
                style={{
                    width: "12rem",
                    display: "inline-block",
                    cursor: "pointer",
                }}
                onClick={() => this.lock()}
            >
                <img
                    className="card-img-top"
                    src={this.props.imgUrl}
                    alt="Card cap"
                />
                <div className="card-body">
                    <h5 className="card-title">{this.props.projectName}</h5>
                    <p className="card-text text-secondary">
                        {this.props.projectDescription}
                    </p>
                </div>
            </div>
        );
    }
}
