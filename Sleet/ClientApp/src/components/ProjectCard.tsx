import * as ProjectCardStore from "../store/ProjectCard"
import { RouteComponentProps } from 'react-router';
import * as React from "react";
import { connect } from "react-redux";
import { ApplicationState } from '../store/index';

type ProjectCardProps =
    ProjectCardStore.ProjectCardState &
    typeof ProjectCardStore.actionCreators &
    RouteComponentProps<{}>;

export class ProjectCard extends React.PureComponent<ProjectCardProps>{
    public render() {
        return (
            <React.Fragment>
                <div className="card" style={{ width: "18rem" }}>
                    <img className="card-img-top" src={this.props.imageUrl } alt="Card image cap"/>
                    <div className="card-body">
                        <h5 className="card-title">{ this.props.projectName }</h5>
                        <p className="card-text">{ this.props.projectDescription }</p>
                        <button type="button" className="btn btn-success" onClick={() => this.props.lock() }>Lock!</button>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}

export default connect(
    (state: ApplicationState) => state.projectcard,
    ProjectCardStore.actionCreators
)(ProjectCard);