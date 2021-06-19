import { PureComponent } from "react";
import * as ProjectCardStore from "../store/ProjectCard"
import { RouteComponentProps } from 'react-router';
import React from "react";
import { connect } from "react-redux";

type ProjectCardProps = ProjectCardStore.ProjectCardState &
    typeof ProjectCardStore.ProjectCardActionCreator &
    RouteComponentProps<{}>;

export class ProjectCard extends PureComponent<ProjectCardProps>{
    public render() {
        return (
            <React.Fragment>
                <div className="card" style={{width: "18rem"}}>
                    <img className="card-img-top" src={this.props.imageUrl} alt="Card image cap"/>
                    <div className="card-body">
                        <h5 className="card-title">{ this.props.projectName}</h5>
                        <p className="card-text">{ this.props.projectDescription }</p>
                        <button type="button" className="btn btn-success" onClick={() => this.props.lock()}>Lock!</button>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}

export default connect(
    (state: ProjectCardStore.ProjectCardState) => state,
    ProjectCardStore.ProjectCardActionCreator
)(ProjectCard);