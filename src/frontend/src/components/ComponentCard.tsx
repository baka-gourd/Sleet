import { type } from "os";
import React, { Component } from "react";

type ComponentCardProps = {
    imgUrl: string;
    projectName: string;
    projectDescription: string;
} & typeof ComponentCard.defaultProps;

export default class ComponentCard extends Component<ComponentCardProps> {
    static defaultProps = {
        imgUrl: "112",
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
            <div className="card" style={{ width: "14rem" }}>
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
                    <button
                        type="button"
                        className="btn btn-danger"
                        onClick={() => this.lock()}
                    >
                        Lock!
                    </button>
                    <button
                        type="button"
                        className="btn btn-success"
                        onClick={() => this.unlock()}
                    >
                        Unlock!
                    </button>
                </div>
            </div>
        );
    }
}
