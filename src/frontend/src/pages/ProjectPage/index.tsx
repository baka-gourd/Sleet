import React from "react";
import { connect } from "react-redux";
import { RouteComponentProps } from "react-router-dom";
import { ApplicationState } from "../../store";
import * as ProjectPageStore from "../../store/ProjectPage";

type ProjectPagesProps = ProjectPageStore.ProjectPageState &
    typeof ProjectPageStore.actionCreators &
    RouteComponentProps<{}>;

class ProjectPage extends React.PureComponent<ProjectPagesProps> {
    render() {
        return (
            <React.Fragment>
                <ul>
                    {this.props.projects.map((num, index) => {
                        return <li key={index}>{num}</li>;
                    })}
                </ul>
                <button
                    type="button"
                    className="btn btn-primary"
                    onClick={() => this.props.prev()}
                >
                    Prev
                </button>
                <button
                    type="button"
                    className="btn btn-primary"
                    onClick={() => this.props.next()}
                >
                    Next
                </button>
            </React.Fragment>
        );
    }

    getPrijectList() {
        return () => {};
    }
}

export default connect(
    (state: ApplicationState) => state.projectPage,
    ProjectPageStore.actionCreators
)(ProjectPage);
