import React from "react";
import { connect } from "react-redux";
import { RouteComponentProps } from "react-router-dom";
import { ApplicationState } from "../../store";
import * as ProjectPageStore from "../../store/ProjectPage";

type ProjectPagesProps = ProjectPageStore.ProjectPageState &
    typeof ProjectPageStore.actionCreators &
    RouteComponentProps<{}>;

class ProjectPage extends React.PureComponent<ProjectPagesProps> {
    wordInput = React.createRef<HTMLInputElement>();

    handleWordOnBlur = () => {
        if (this.wordInput.current?.value === undefined) return;
        this.props.setWord(this.wordInput.current?.value);
    };

    handleWordOnEnter = (
        event: React.KeyboardEvent<HTMLInputElement> | undefined
    ) => {
        if (this.wordInput.current?.value === undefined) return;
        if (event === undefined) return;
        if (event.key !== "Enter") return;
        this.props.setWord(this.wordInput.current?.value);
        this.props.filterList();
    };
    render() {
        return (
            <React.Fragment>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <span className="input-group-text" id="basic-addon1">
                            项目名称
                        </span>
                    </div>
                    <input
                        type="text"
                        className="form-control"
                        placeholder="项目名称（回车或点击其他位置刷新）"
                        aria-label="projectname"
                        aria-describedby="basic-addon1"
                        ref={this.wordInput}
                        onBlur={() => {
                            this.handleWordOnBlur();
                            this.props.filterList();
                        }}
                        onKeyDown={(event) => this.handleWordOnEnter(event)}
                    />
                </div>
                <ul>
                    {this.props.displayProjects.map((num, index) => {
                        return <li key={index}>{num}</li>;
                    })}
                </ul>
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
